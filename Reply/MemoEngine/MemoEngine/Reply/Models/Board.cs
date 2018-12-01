using System;

namespace Reply.Common
{
    public class Board
    {
        /// <summary>
        /// 날짜값을 받아서 24시간내의 글이면 New 이미지 붙이기
        /// </summary>
        public static string GetNewImg(object postDate)
        {
            TimeSpan ts = DateTime.Now - Convert.ToDateTime(postDate);
            string result = "";
            if (ts.TotalHours < 24) // 24시간 내의 글이면...
            {
                result = "<img src='images/new.gif' />";
            }
            return result;
        }

        /// <summary>
        /// 인코딩 방식에 따른 Content 문자열 반환 : Text/Mixed/HTML
        /// </summary>
        public static string ConvertContentByEncoding(string content, string encoding)
        {
            string result = String.Empty;
            encoding = encoding.ToLower(); // 소문자로 비교
            if (encoding == "text") // 태그 실행 방지/소스 그대로
            {
                result =
                    content
                        .Replace("&", "&amp;")
                        .Replace("<", "&lt;")
                        .Replace(">", "&gt;")
                        .Replace("\r\n", "<br />")
                        .Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            }
            else if (encoding == "mixed") // 태그 실행
            {
                result = content.Replace("\r\n", "<br />");
            }
            else // HTML로 표시
            {
                result = content;
            }
            return result; 
        }

    }
}
