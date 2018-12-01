using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;

namespace MemoEngine.Modules.SupportManager
{
    /// <summary>
    /// Excel 파일로 List of T 형태의 컬렉션을 다운로드해주는 클래스
    /// </summary>
    public class ExcelDownUtility
    {
        public static void ExcelDownloadWithTabSeparatedValues<T>(
            IEnumerable<T> data, TextWriter output)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentEncoding =
                System.Text.Encoding.Default;
            HttpContext.Current.Response.AddHeader(
                "content-disposition", "attachment;filename=" +
                HttpUtility.UrlEncode(System.DateTime.Now.ToString(),
                System.Text.Encoding.UTF8) + ".xls");
            HttpContext.Current.Response.AddHeader(
                "Content-Type", "application/vnd.ms-excel");

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName);
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Write(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    output.Write("\t");
                }
                output.WriteLine();
            }

            HttpContext.Current.Response.End();
        }
    }
}
