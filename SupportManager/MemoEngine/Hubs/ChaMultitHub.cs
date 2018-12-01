using MemoEngine.ViewModels.ChatRoomViewModel;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MemoEngine.Hubs
{
    [HubName("chatMulti")]
    public class ChatMultiHub : Hub
    {
        /// <summary>
        /// 특정 방에 특정 사용자가 들어왔을 때 메시지 표시
        /// </summary>
        public void JoinRoom(string room, string name)
        {
            // 특정 그룹에 다른 사용자들에게 데이터 전송
            //Clients.OthersInGroup(room).newNotification(name + " : 들어왔습니다.");
            Groups.Add(Context.ConnectionId, room); // 특정 그룹에 나를 포함
        }

        /// <summary>
        /// 특정 방에서 특정 사용자가 나갔을 때 메시지 표시
        /// </summary>
        public void LeaveRoom(string room, string name)
        {
            //Clients.OthersInGroup(room).newNotification(name + " : 나갔습니다.");
            Groups.Remove(Context.ConnectionId, room); // 특정 그룹에서 나를 제거
        }


        #region Data Members

        private static List<ChatUserDetail> ConnectedUsers = new List<ChatUserDetail>();
        private static List<ChatMessageDetail> CurrentMessage = new List<ChatMessageDetail>();

        #endregion

        #region Methods

        /// <summary>
        /// 특정 사용자 접속 처리
        /// - 접속한 사용자 이름을 ConnectedUsers 컬렉션에 저장시킴
        /// </summary>
        /// <param name="userName"></param>
        public void Connect(string room, string userName)
        {
            var id = Context.ConnectionId;

            Groups.Add(Context.ConnectionId, room); // 특정 그룹에 나를 포함

            // 현재 접속자의 고유ID값이 컬렉션에 없다면, ConnectionId와 UserName을 저장함
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new ChatUserDetail { RoomName = room, ConnectionId = id, UserName = userName });

                // 현재 접속한 사용자에게는 지금 접속중인 사용자 리스트와 메시지들을 전송받음
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // 현재 접속한 나(Caller)를 제외한 다른 사용자에게 내가 참여했다는 메시지를 표시
                Clients.OthersInGroup(room).onNewUserConnected(room, id, userName);
                //Clients.AllExcept(id).onNewUserConnected(room, id, userName);
            }
        }

        /// <summary>
        /// 모든 사용자에게 채팅 메시지 전송
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        public void SendMessageToAll(string room, string userName, string message)
        {
            // 최근 200개의 메시지를 캐시에 저장
            AddMessageinCache(userName, message);

            // 채팅 메시지를 브로드캐스팅
            Clients.Group(room).messageReceived(userName, message);
        }

        /// <summary>
        /// 일대일 채팅
        /// - 특정 사용자에게 개인 메시지 보내기 기능
        /// </summary>
        /// <param name="toUserId"></param>
        /// <param name="message"></param>
        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }

        }

        //[!] 히트 카운트
        private static int _hitCounter = 0; // 총 방문수 

        public override System.Threading.Tasks.Task OnConnected()
        {
            Interlocked.Increment(ref _hitCounter); // 1증가
            Clients.All.hitRecoreded(_hitCounter); // 방문자 증가 정보를 클라이언트에게 전송
            
            return base.OnConnected();
        }

        /// <summary>
        /// 웹브라우저 등을 닫고 채팅을 종료했을 때 코드 구현 부분
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Interlocked.Decrement(ref _hitCounter); // 1감소
            Clients.All.hitRecoreded(_hitCounter);


            // 현재 접속자의 고유 접속 번호가 컬렉션에 존재하는지 확인
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                // 컬렉션 리스트에서 제거
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                // 현재 대화방을 나간 사용자에 대한 정보를 브로드캐스팅해서 "~님이 나가셨습니다." 식으로 메시지 출력
                //Clients.All.onUserDisconnected(id, item.UserName);
                Clients.Group(item.RoomName).onUserDisconnected(id, item.UserName);
            }

            return base.OnDisconnected(stopCalled);
        }


        #endregion

        #region private Messages

        private void AddMessageinCache(string userName, string message)
        {
            CurrentMessage.Add(new ChatMessageDetail { UserName = userName, Message = message });

            if (CurrentMessage.Count > 200)
            {
                CurrentMessage.RemoveAt(0);
            }
        }

        #endregion
    }
}