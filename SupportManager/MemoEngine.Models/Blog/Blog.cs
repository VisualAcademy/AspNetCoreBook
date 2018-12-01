using System.Collections.Generic;

namespace MemoEngine.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        
        public List<Post> Posts { get; set; }

        //public string BloggerName { get; set; }
        //public System.DateTime DateCreated { get; set; }
    }
}

