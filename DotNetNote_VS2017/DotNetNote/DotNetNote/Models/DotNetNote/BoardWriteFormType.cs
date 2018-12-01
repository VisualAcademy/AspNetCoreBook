namespace DotNetNote.Models
{
    /// <summary>
    /// 게시판의 글쓰기 폼 구성 분류(Write, Modify, Reply)
    /// </summary>
    public enum BoardWriteFormType
    {
        /// <summary>
        /// 글 쓰기 페이지
        /// </summary>
        Write,
        /// <summary>
        /// 글 수정 페이지
        /// </summary>
        Modify,
        /// <summary>
        /// 글 답변 페이지
        /// </summary>
        Reply
    }

    public static class BoardWriteFormTypeExtensions
    {
        public static string ToFriendlyString(this BoardWriteFormType bwft)
        {
            string r = "";

            switch (bwft)
            {
                case BoardWriteFormType.Write:
                    r = "글 쓰기 페이지";
                    break;
                case BoardWriteFormType.Modify:
                    r = "글 수정 페이지";
                    break;
                case BoardWriteFormType.Reply:
                    r = "글 답변 페이지";
                    break;
                default:
                    r = "글 쓰기 페이지";
                    break;
            }

            return r; 
        }

        //// 참고 : 문자열을 열거형으로 변환
        //protected string FuncStringToEnum(object o)
        //{
        //    string sEnum = "";
        //    if (o != null)
        //    {
        //        sEnum = o.ToString();
        //    }

        //    BoardWriteFormType kor = 
        //        (BoardWriteFormType)System.Enum.Parse(
        //            typeof(BoardWriteFormType), sEnum);

        //    sEnum = kor.ToFriendlyString();

        //    return sEnum;
        //}
    }
}
