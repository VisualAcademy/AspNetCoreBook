using System;

namespace MemoEngine.Common
{
    public partial class FrmBlobUploadTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AzureBlobStorageManager.UploadBlob();
        }
    }
}