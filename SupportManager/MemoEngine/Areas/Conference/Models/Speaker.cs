using System.ComponentModel.DataAnnotations;

namespace MemoEngine.Models
{
    /// <summary>
    /// 스피커 클래스
    /// </summary>
    public class Speaker
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} 필요")]
        [Display(Name = "스피커 이름")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Speaker 클래스 초기 버전
    /// </summary>
    public class SpeakerOld
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
