using System;

namespace Dul
{
    public class HtmlUtility
    {
        #region EncodeWithTabAndSpace() 함수
        /// <summary>
        /// 주어진 문자열을 HTML코드로 바꿈. 특히 탭이나 공백도 처리함. (바꿀 문자열)
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string EncodeWithTabAndSpace(string strContent)
        {
            string strTemp = "";
            if (strContent == null || strContent.Length == 0)
            {
                strTemp = "";
            }
            else
            {
                strTemp = strContent;
                strTemp = strTemp.Replace("&", "&amp;");
                strTemp = strTemp.Replace(">", "&gt;");
                strTemp = strTemp.Replace("<", "&lt;");
                strTemp = strTemp.Replace("\r\n", "<br />");
                strTemp = strTemp.Replace("\"", "&#34;");
                strTemp = strTemp.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
                strTemp = strTemp.Replace(" " + " ", "&nbsp;&nbsp;");
            }
            return strTemp;
        }
        #endregion


        #region Encode() 함수
        /// <summary>
        /// 주어진 문자열을 HTML코드로 바꿈. (바꿀 문자열)
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string Encode(string strContent)
        {
            string strTemp = "";
            if (String.IsNullOrEmpty(strContent))
            {
                strTemp = "";
            }
            else
            {
                strTemp = strContent;
                strTemp = strTemp.Replace("&", "&amp;");
                strTemp = strTemp.Replace(">", "&gt;");
                strTemp = strTemp.Replace("<", "&lt;");
                strTemp = strTemp.Replace("\r\n", "<br>");
                strTemp = strTemp.Replace("\"", "&#34;");
            }
            return strTemp;
        }
        #endregion
    }
}
