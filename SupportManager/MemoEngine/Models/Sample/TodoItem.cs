using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoEngine.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IsDone { get; set; }
    }
}