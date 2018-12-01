using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoEngine.ViewModels.ChatRoomViewModel
{
    public class ChatMessageDetail
    {
        public string RoomName { get; set; }

        public string UserName { get; set; }
        public string Message { get; set; }

        public string FontColor { get; set; }
        public int FontSize { get; set; }
    }
}