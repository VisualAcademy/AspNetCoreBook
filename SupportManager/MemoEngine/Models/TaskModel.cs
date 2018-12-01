using System;

namespace MemoEngine.Models
{
    /// <summary>
    /// Tasks(할일) 테이블과 일대일
    /// </summary>
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
