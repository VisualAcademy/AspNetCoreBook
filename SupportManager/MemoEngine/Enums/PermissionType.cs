namespace MemoEngine.Enums
{
    /// <summary>
    /// 게시판 퍼미션 형식
    /// </summary>
    public enum PermissionType
    {
        /// <summary>
        /// 접근거부
        /// </summary>
        NoAccess,
        /// <summary>
        /// 리스트 보기
        /// </summary>
        List,
        /// <summary>
        /// 상세 보기(아티클 읽기)
        /// </summary>
        ReadArticle,
        /// <summary>
        /// 파일 다운로드
        /// </summary>
        Download,
        /// <summary>
        /// 글쓰기
        /// </summary>
        Write,
        /// <summary>
        /// 업로드
        /// </summary>
        Upload,
        /// <summary>
        /// 관리
        /// </summary>
        Extra,
        /// <summary>
        /// 모든권한
        /// </summary>
        Admin,
        /// <summary>
        /// 댓글
        /// </summary>
        Comment
    }
}
