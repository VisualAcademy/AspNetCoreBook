using System;

namespace Reply.Entity
{
    /// <summary>
    /// Reply 테이블과 일대일로 매치되는 클래스
    /// </summary>
    public class ReplyEntity
    {
        public int Num { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string PostIP { get; set; }
        public string Content { get; set; }
        public string Password { get; set; }
        public int ReadCount { get; set; }
        public string Encoding { get; set; }
        public string Homepage { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyIP { get; set; }
        //
        public int Ref { get; set; }
        public int Step { get; set; }
        public int RefOrder { get; set; }
    }
}
