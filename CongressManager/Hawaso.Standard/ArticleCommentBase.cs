using System;
using System.ComponentModel.DataAnnotations;

namespace Hawaso.Standard
{
    /// <summary>
    /// 댓글 뷰 모델 클래스 
    /// 댓글 클래스: Comment, CommentEntity, ... 
    /// NoteComment 클래스: NoteComments 테이블과 일대일 매핑되는 ViewModel 클래스
    /// </summary>
    public class ArticleCommentBase
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 일련번호
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 게시판 이름
        /// </summary>
        public string BoardName { get; set; }

        /// <summary>
        /// 게시판 아티클 번호
        /// </summary>
        public int BoardNum { get; set; }

        /// <summary>
        /// 게시판 아티클 번호 
        /// </summary>
        public int BoardId { get; set; }

        /// <summary>
        /// 게시판 아티클 번호 
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// 사용자 UID
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// 작성자 이름
        /// </summary>
        [Required(ErrorMessage = "이름을 입력하세요.")]
        public string Name { get; set; }

        /// <summary>
        /// 암호
        /// </summary>
        [Required(ErrorMessage = "암호를 입력하세요.")]
        public string Password { get; set; }

        /// <summary>
        /// 코멘트
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 의견 == 코멘트
        /// </summary>
        [Required(ErrorMessage = "의견을 입력하세요.")]
        public string Opinion { get; set; }

        /// <summary>
        /// 댓글 작성일
        /// </summary>
        public DateTime PostDate { get; set; }
    }
}
