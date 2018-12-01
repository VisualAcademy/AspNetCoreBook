using System;
using System.IO;

namespace Dul
{
    public class BoardLibrary
    {
        #region 각 글의 Step별 들여쓰기 처리
        /// <summary>
        /// 각 글의 Step별 들여쓰기 처리
        /// </summary>
        /// <param name="objStep">1, 2, 3</param>
        /// <returns>Re 이미지를 포함한 Step만큼 들여쓰기</returns>
        public static string FuncStep(object objStep)
        {
            int intStep = Convert.ToInt32(objStep);
            string strTemp = String.Empty;
            if (intStep == 0)
            {
                strTemp = String.Empty;
            }
            else
            {
                for (int i = 0; i < intStep; i++)
                {
                    strTemp = String.Format("<img src=\"{0}\" height=\"{1}\" width=\"{2}\">", "images/blank.gif", "0", (intStep * 15));
                }
                strTemp += "<img src=\"images/re.gif\">";
            }
            return strTemp;
        }
        #endregion

        #region 코멘트 개수를 표현하는 메서드
        /// <summary>
        /// 코멘트 개수를 표현하는 메서드
        /// </summary>
        /// <param name="objCommentCount">코멘트 수</param>
        /// <returns>코멘트 이미지와 함께 숫자 표시</returns>
        public static string ShowCommentCount(object objCommentCount)
        {
            string strTemp = "";
            try
            {
                if (Convert.ToInt32(objCommentCount) > 0)
                {
                    strTemp = "<img src=\"images/commentcount.gif\" />";
                    strTemp += "(" + objCommentCount.ToString() + ")";
                }
            }
            catch (Exception)
            {
                strTemp = "";
            }
            return strTemp;
        }
        #endregion

        #region 24시간내에 올라온 글 new 이미지 표시하기
        /// <summary>
        /// 24시간내에 올라온 글 new 이미지 표시하기
        /// </summary>
        public static string FuncNew(object strDate)
        {
            if (strDate != null)
            {
                if (!String.IsNullOrEmpty(strDate.ToString()))
                {
                    DateTime originDate = Convert.ToDateTime(strDate);

                    TimeSpan objTs = DateTime.Now - originDate;
                    string newImage = "";
                    if (objTs.TotalMinutes < 1440)
                    {
                        newImage = "<img src=\"images/new.gif\">";
                    }
                    return newImage;
                }
            }
            return "";
        }
        #endregion

        #region 넘겨온 날짜 형식이 오늘 날짜면 시간 표시
        /// <summary>
        /// 넘겨온 날짜 형식이 오늘 날짜면 시간 표시, 
        /// 그렇지않으면 날짜표시
        /// </summary>
        /// <param name="objPostDate"></param>
        /// <returns></returns>
        public static string FuncShowTime(object objPostDate)
        {
            if (objPostDate != null)
            {
                if (!String.IsNullOrEmpty(objPostDate.ToString()))
                {
                    string strPostDate =
                      Convert.ToDateTime(objPostDate).ToShortDateString();
                    if (strPostDate == DateTime.Now.ToShortDateString())
                    {
                        return Convert.ToDateTime(objPostDate).ToShortTimeString();
                    }
                    else
                    {
                        return strPostDate;
                    }
                }
            }
            return "-";
        }
        #endregion

        #region ConvertToFileSize() 함수
        /// <summary>
        /// 파일 크기를 계산해서 알맞은 단위로 변환해줌. (바이트 수)
        /// </summary>
        /// <param name="intByte"></param>
        /// <returns></returns>
        public static string ConvertToFileSize(int intByte)
        {
            int intFileSize = Convert.ToInt32(intByte);
            string strResult = "";
            if (intFileSize >= 1048576)
            {
                strResult = string.Format("{0:F} MB", (intByte / 1048576));
            }
            else
            {
                if (intFileSize >= 1024)
                {
                    strResult = string.Format("{0} KB", (intByte / 1024));
                }
                else
                {
                    strResult = intByte + " Byte(s)";
                }
            }
            return strResult;
        }
        #endregion

        #region DownloadType() 함수
        /// <summary>
        /// 다운로드할 파일의 확장자를 통해 아이콘을 결정. (파일 이름, alt 메세지로 넣을 문자열)
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="altString"></param>
        /// <returns></returns>
        public static string DownloadType(string strFileName, string altString)
        {
            string strFileExt = Path.GetExtension(strFileName).Replace(".", "").ToLower();
            string strResult = "";
            switch (strFileExt)
            {
                case "ace":
                    strResult = "<img src='images/ext/ext_ace.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "ai":
                    strResult = "<img src='images/ext/ext_ai.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "alz":
                    strResult = "<img src='images/ext/ext_alz.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "arj":
                    strResult = "<img src='images/ext/ext_arj.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "asa":
                    strResult = "<img src='images/ext/ext_asa.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "asax":
                    strResult = "<img src='images/ext/ext_asax.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "ascx":
                    strResult = "<img src='images/ext/ext_ascx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "asf":
                    strResult = "<img src='images/ext/ext_asf.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "asmx":
                    strResult = "<img src='images/ext/ext_asmx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "asp":
                    strResult = "<img src='images/ext/ext_asp.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "aspx":
                    strResult = "<img src='images/ext/ext_aspx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "asx":
                    strResult = "<img src='images/ext/ext_asx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "au":
                    strResult = "<img src='images/ext/ext_au.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "avi":
                    strResult = "<img src='images/ext/ext_avi.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "bat":
                    strResult = "<img src='images/ext/ext_bat.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "bmp":
                    strResult = "<img src='images/ext/ext_bmp.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "c":
                    strResult = "<img src='images/ext/ext_c.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "cs":
                    strResult = "<img src='images/ext/ext_cs.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "csproj":
                    strResult = "<img src='images/ext/ext_csproj.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "cab":
                    strResult = "<img src='images/ext/ext_cab.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "chm":
                    strResult = "<img src='images/ext/ext_chm.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "com":
                    strResult = "<img src='images/ext/ext_com.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "config":
                    strResult = "<img src='images/ext/ext_config.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "cpp":
                    strResult = "<img src='images/ext/ext_cpp.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "css":
                    strResult = "<img src='images/ext/ext_css.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "csv":
                    strResult = "<img src='images/ext/ext_csv.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "disco":
                    strResult = "<img src='images/ext/ext_disco.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "dll":
                    strResult = "<img src='images/ext/ext_dll.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "doc":
                    strResult = "<img src='images/ext/ext_doc.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "eml":
                    strResult = "<img src='images/ext/ext_eml.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "exe":
                    strResult = "<img src='images/ext/ext_exe.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "gif":
                    strResult = "<img src='images/ext/ext_gif.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "gz":
                    strResult = "<img src='images/ext/ext_gz.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "h":
                    strResult = "<img src='images/ext/ext_h.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "hlp":
                    strResult = "<img src='images/ext/ext_hlp.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "htm":
                    strResult = "<img src='images/ext/ext_htm.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "html":
                    strResult = "<img src='images/ext/ext_html.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "hwp":
                    strResult = "<img src='images/ext/ext_hwp.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "hwt":
                    strResult = "<img src='images/ext/ext_hwt.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "inc":
                    strResult = "<img src='images/ext/ext_inc.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "ini":
                    strResult = "<img src='images/ext/ext_ini.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "jpg":
                    strResult = "<img src='images/ext/ext_jpg.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "jpeg":
                    strResult = "<img src='images/ext/ext_jpeg.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "js":
                    strResult = "<img src='images/ext/ext_js.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "lzh":
                    strResult = "<img src='images/ext/ext_lzh.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "m3u":
                    strResult = "<img src='images/ext/ext_m3u.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "max":
                    strResult = "<img src='images/ext/ext_max.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mdb":
                    strResult = "<img src='images/ext/ext_mdb.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mid":
                    strResult = "<img src='images/ext/ext_mid.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mov":
                    strResult = "<img src='images/ext/ext_mov.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mp2":
                    strResult = "<img src='images/ext/ext_mp2.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mp3":
                    strResult = "<img src='images/ext/ext_mp3.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mpe":
                    strResult = "<img src='images/ext/ext_mpe.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mpeg":
                    strResult = "<img src='images/ext/ext_mpeg.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "mpg":
                    strResult = "<img src='images/ext/ext_mpg.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "msi":
                    strResult = "<img src='images/ext/ext_exe.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "":
                    strResult = "<img src='images/ext/ext_none.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "pcx":
                    strResult = "<img src='images/ext/ext_pcx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "pdb":
                    strResult = "<img src='images/ext/ext_pdb.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "pdf":
                    strResult = "<img src='images/ext/ext_pdf.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "pls":
                    strResult = "<img src='images/ext/ext_pls.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "png":
                    strResult = "<img src='images/ext/ext_png.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "ppt":
                    strResult = "<img src='images/ext/ext_ppt.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "psd":
                    strResult = "<img src='images/ext/ext_psd.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "ra":
                    strResult = "<img src='images/ext/ext_ra.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "ram":
                    strResult = "<img src='images/ext/ext_ram.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "rar":
                    strResult = "<img src='images/ext/ext_rar.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "reg":
                    strResult = "<img src='images/ext/ext_reg.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "resx":
                    strResult = "<img src='images/ext/ext_resx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "rm":
                    strResult = "<img src='images/ext/ext_rm.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "rmi":
                    strResult = "<img src='images/ext/ext_rmi.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "rtf":
                    strResult = "<img src='images/ext/ext_rtf.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "sql":
                    strResult = "<img src='images/ext/ext_sql.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "swf":
                    strResult = "<img src='images/ext/ext_swf.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "sys":
                    strResult = "<img src='images/ext/ext_sys.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "tar":
                    strResult = "<img src='images/ext/ext_tar.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "tga":
                    strResult = "<img src='images/ext/ext_tga.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "tif":
                    strResult = "<img src='images/ext/ext_tif.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "ttf":
                    strResult = "<img src='images/ext/ext_ttf.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "txt":
                    strResult = "<img src='images/ext/ext_txt.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "vb":
                    strResult = "<img src='images/ext/ext_vb.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "vbs":
                    strResult = "<img src='images/ext/ext_vbs.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "vbdisco":
                    strResult = "<img src='images/ext/ext_vbdisco.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "wav":
                    strResult = "<img src='images/ext/ext_wav.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "wax":
                    strResult = "<img src='images/ext/ext_wax.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "webinfo":
                    strResult = "<img src='images/ext/ext_webinfo.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "wma":
                    strResult = "<img src='images/ext/ext_wma.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "wmv":
                    strResult = "<img src='images/ext/ext_wmv.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "wmx":
                    strResult = "<img src='images/ext/ext_wmx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "wri":
                    strResult = "<img src='images/ext/ext_wri.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "wvx":
                    strResult = "<img src='images/ext/ext_wvx.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "xls":
                    strResult = "<img src='images/ext/ext_xls.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "xml":
                    strResult = "<img src='images/ext/ext_xml.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                case "zip":
                    strResult = "<img src='images/ext/ext_zip.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;

                default:
                    strResult = "<img src='images/ext/ext_unknown.gif' width='16' height='16' border='0' alt='" + altString + "'>"; break;
            }
            return strResult;
        }
        #endregion

        #region 파일 다운로드 기능
        /// <summary>
        /// 파일 다운로드 기능
        /// 주의 : 각 필드에 NULL 값이 들어가면 에러남
        /// </summary>
        /// <param name="intNum"></param>
        /// <param name="strFileName"></param>
        /// <param name="strFileSize"></param>
        /// <returns></returns>
        public static string FuncFileDownSingle(int id, string strFileName, string strFileSize)
        {
            if (strFileName.Length > 0)
            {
                return "<a href=\"BoardDown.aspx?Id=" + id.ToString() + "\">" + DownloadType(strFileName, strFileName + "(" + ConvertToFileSize(Convert.ToInt32(strFileSize)) + ")") + "</a>";
            }
            else
            {
                return "-";
            }
        }
        #endregion

        #region IsPhoto() 함수
        /// <summary>
        /// 첨부된 파일이 이미지 파일인지 검사
        /// </summary>
        /// <param name="strFileNameTemp"></param>
        public static bool IsPhoto(string strFileNameTemp)
        {
            string strFileExt = Path.GetExtension(strFileNameTemp).Replace(".", "").ToLower();
            bool blnResult = false;
            if (strFileExt == "gif" || strFileExt == "jpg" || strFileExt == "jpeg" || strFileExt == "png")
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }
        #endregion
    }
}
