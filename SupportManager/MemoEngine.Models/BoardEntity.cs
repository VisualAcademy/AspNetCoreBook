namespace MemoEngine.Models
{
    /// <summary>
    /// BoardEntity: 게시판 별칭과 제목만을 가지는 간단한 엔티티 클래스
    /// </summary>
    public class BoardEntity
    {
        public string BoardAlias { get; set; }
        public string Title { get; set; }
    }
}
