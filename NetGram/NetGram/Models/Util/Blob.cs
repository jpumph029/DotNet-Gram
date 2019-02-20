using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Models.Util
{
    public class Blob
    {
        //Bob house
        public CloudStorageAccount CloudStorageAccount { get; set; }
        //Cloud Bob
        public CloudBlobClient CloudBlobClient{ get; set; }

        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["ConnectionStrings:BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        //Get Container
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            return cbc;
        }

        //Get Bob
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            //var container = CloudBlobClient.GetContainerReference(containerName);
            CloudBlobContainer container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);

            return blob;
        }
        //Upload File to bob
        public void UploadFile(CloudBlobContainer cloudBlobContainer, string fileName, string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(filePath);
        }
    }
}
