using System;

namespace MemoEngine.Entities
{
    /// <summary>
    /// Domains 테이블과 일대일
    /// </summary>
    public class Member
    {
        public int Id { get; set; } 

        // 필수 속성
        public string DomainId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        // 자식 클래스 지정
        public Profile Profile { get; set; }
    }
}
