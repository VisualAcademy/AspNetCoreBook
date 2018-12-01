namespace MemoEngine.Enums
{
    /// <summary>
    /// 게시판의 리스트 처리 형태
    /// </summary>
    public enum BoardStyleType
    {
        /// <summary>
        /// 기본(일반) 게시판 형태
        /// </summary>
        Board = 0,
        /// <summary>
        /// 강좌형 게시판 형태(1~100번 순서대로 리스트 출력)
        /// </summary>
        Lecture = 1,
        /// <summary>
        /// 한줄메모장 형태
        /// </summary>
        Memo = 2, 
        /// <summary>
        /// 이벤트 신청 게시판 형태 : 참여하기 버튼 보임
        /// </summary>
        Event = 3
    }
}