using System;
using System.ComponentModel.DataAnnotations;

namespace Basic.Models
{
    /// <summary>
    /// Basic 모델(뷰 모델, 아이템) 클래스: Basics 테이블과 일대일
    /// </summary>
    public class Basic
    {
        [Display(Name = "번호")]
        public int Id { get; set; }

        [Display(Name = "작성자")]
        [Required(ErrorMessage = "* 이름을 작성해 주세요.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "* 이메일을 정확히 입력하세요.")]
        public string Email { get; set; }

        [Display(Name = "제목")]
        [Required(ErrorMessage = "* 제목을 작성해 주세요.")]
        public string Title { get; set; }

        [Display(Name = "작성일")]
        public DateTime PostDate { get; set; }

        [Display(Name = "작성IP")]
        public string PostIp { get; set; }

        [Display(Name = "내용")]
        [Required(ErrorMessage = "* 내용을 작성해 주세요.")]
        public string Content { get; set; }

        [Display(Name = "비밀번호")]
        [Required(ErrorMessage = "* 비밀번호를 작성해 주세요.")]
        public string Password { get; set; }

        [Display(Name = "조회수")]
        public int ReadCount { get; set; }

        [Display(Name = "인코딩")]
        public string Encoding { get; set; } = "Text";

        [Display(Name = "홈페이지")]
        public string Homepage { get; set; }

        [Display(Name = "수정일")]
        public DateTime ModifyDate { get; set; }

        [Display(Name = "수정IP")]
        public string ModifyIp { get; set; }
    }
}
