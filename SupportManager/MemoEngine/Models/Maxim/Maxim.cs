using System;

namespace MemoEngine.Models
{
    /// <summary>
    /// Maxim 모델 클래스: Maxims 테이블과 일대일
    /// </summary>
    public class Maxim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }


        // PM> Enable-Migrations
        // PM> Add-Migration "Add_Maxim_CreationDate"
        // PM> Update-Database


        /// <summary>
        /// 등록일
        /// </summary>
        //public DateTime CreatoinDate { get; set; }
        
        // PM> Add-Migration "ReName_Maxim_CreationDate"
        // PM> Update-Database

        public DateTime CreationDate { get; set; } // Ctrl + Shift + H : 모두 바꾸기
    }
}
