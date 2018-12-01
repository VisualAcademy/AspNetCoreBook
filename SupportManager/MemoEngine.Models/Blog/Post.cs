﻿using System;

namespace MemoEngine.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
