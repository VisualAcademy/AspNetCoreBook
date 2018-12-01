using System.IO;

/// <summary>
/// Dul.dll: Development Utility Library
/// </summary>
namespace Dul
{
    /// <summary>
    /// 파일 처리 관련 기본 유틸리티
    /// </summary>
    public class FileUtility
    {
        #region 중복된 파일명 뒤에 번호 붙이는 메서드 : GetFileNameWithNumbering
        /// <summary>
        /// GetFilePath : 파일명 뒤에 번호 붙이는 메서드
        /// </summary>
        /// <param name="strBaseDirTemp">경로(c:\MyFiles)</param>
        /// <param name="strFileNameTemp">Test.txt</param>
        /// <returns>Test(1).txt</returns>
        public static string GetFileNameWithNumbering(string strBaseDirTemp, string strFileNameTemp)
        {
            string strName = Path.GetFileNameWithoutExtension(strFileNameTemp); // 순수파일명 : Test
            string strExt = Path.GetExtension(strFileNameTemp); //확장자 : .txt
            bool blnExists = true;
            int i = 0;
            while (blnExists)
            {
                //Path.Combine(경로, 파일명) = 경로+파일명
                if (File.Exists(Path.Combine(strBaseDirTemp, strFileNameTemp)))
                {
                    strFileNameTemp = strName + "(" + ++i + ")" + strExt; // Test(3).txt
                }
                else
                {
                    blnExists = false;
                }
            }
            return strFileNameTemp;
        }
        #endregion
    }
}
