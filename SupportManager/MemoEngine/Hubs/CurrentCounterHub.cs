using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading;

namespace MemoEngine.Hubs
{
    [HubName("currentCounter")]
    public class CurrentCounterHub : Hub
    {
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

            return base.OnDisconnected(stopCalled);
        }
    }
}
