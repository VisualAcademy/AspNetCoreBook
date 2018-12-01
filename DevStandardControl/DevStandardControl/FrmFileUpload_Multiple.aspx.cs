using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace DevStandardControl
{
    public partial class FrmFileUpload_Multiple : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // 업로드된 파일이 있는지 확인
            if (txtFiles.HasFiles)
            {
                string path = Server.MapPath("~/files/");
                foreach (HttpPostedFile file in txtFiles.PostedFiles)
                {
                    try
                    {
                        // 파일명
                        string fileName =
                            Path.GetFileName(file.FileName);
                        file.SaveAs(Path.Combine(path, fileName)); 
                        lblDisplay.Text += fileName + "<br />";
                    }
                    catch (Exception ex)
                    {
                        lblDisplay.Text = "에러 발생: " + ex.Message;
                    }
                }
            }
        }
    }
}
