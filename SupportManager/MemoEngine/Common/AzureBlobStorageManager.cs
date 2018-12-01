using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types

namespace MemoEngine.Common
{
    public class AzureBlobStorageManager
    {
        public static void UploadBlob()
        {
            string containerName = "MemoEngine".ToLower(); // 컨테이너 이름은 소문자
            string blobName = "RedPlus.jpg";

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AZURE_STORAGE_ACCESSKEY"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();
            container.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(@"c:\Temp\RedPlus.jpg"))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        public static void DownloadBlob()
        {
            string containerName = "MemoEngine".ToLower(); // 컨테이너 이름은 소문자
            string blobName = "RedPlus.jpg";

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AZURE_STORAGE_ACCESSKEY"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Retrieve reference to a blob named "photo1.jpg".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Save blob contents to a file.
            using (var fileStream = System.IO.File.OpenWrite(@"C:\Temp\Down\" + blobName))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }

        public static void DeleteBlob()
        {
            string containerName = "MemoEngine".ToLower(); // 컨테이너 이름은 소문자
            string blobName = "RedPlus.jpg";

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AZURE_STORAGE_ACCESSKEY"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Retrieve reference to a blob named "myblob.txt".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Delete the blob.
            blockBlob.Delete();
        }
    }
}
