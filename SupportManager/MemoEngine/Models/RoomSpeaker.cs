namespace MemoEngine.Models
{
    public class RoomSpeaker
    {
        public int RoomSpeakerId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}