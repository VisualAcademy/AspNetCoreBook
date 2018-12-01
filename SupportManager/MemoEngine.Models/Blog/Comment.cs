namespace MemoEngine.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
