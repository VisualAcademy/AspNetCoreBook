using System.Collections.Generic;

namespace MemoEngine.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RoomSpeaker> RoomSpeakers { get; set; }
    }
}
