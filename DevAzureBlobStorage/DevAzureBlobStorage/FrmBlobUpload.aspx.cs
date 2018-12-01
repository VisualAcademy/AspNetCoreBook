using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;

namespace DevAzureBlobStorage
{
    public partial class FrmBlobUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtFileName.PostedFile != null 
                && txtFileName.PostedFile.ContentLength > 0)
            {
                var blobName = txtFileName.FileName; 
                if (Convert.ToBoolean(
                    ConfigurationManager.AppSettings[
                        "AZURE_STORAGE_ENABLE"].ToString()))
                {
                    //[!] Azure에 업로드
                    string accessKey = ConfigurationManager.AppSettings[
                        "AZURE_STORAGE_ACCESSKEY"].ToString();
                    string containerName = "photos".ToLower();


                    //[!] 컨테이너가 없으면 생성
                    // Retrieve storage account from connection string.
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(accessKey);
                    // Create the blob client.
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    // Retrieve a reference to a container.
                    CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                    // Create the container if it doesn't already exist.
                    container.CreateIfNotExists();
                    container.SetPermissions(
                        new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                    //[!] 파일 업로드
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName); // 파일명 지정
                    blockBlob.Properties.ContentType = txtFileName.PostedFile.ContentType;
                    blockBlob.UploadFromStream(txtFileName.FileContent); // 업로드 

                    this.imgFile.ImageUrl = $"https://webcampstorage.blob.core.windows.net/photos/{blobName}";
                }
                else
                {
                    //[!] Local에 업로드

                }
            }
        }
    }
}