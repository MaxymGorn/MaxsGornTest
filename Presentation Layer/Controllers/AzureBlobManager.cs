
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Windows;

namespace MaxsGornTest.Controllers
{
    public class AzureBlobManager:IDisposable
    {
        public CloudBlobContainer blobContainer { get; private set; }
        private static AzureBlobManager instance;
        private static object syncRoot = new Object();
        private AzureBlobManager()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"].ToString());
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            blobContainer = blobClient.GetContainerReference(ConfigurationManager.AppSettings["BlobContainerName"].ToString());
        }

        public static AzureBlobManager getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new AzureBlobManager();
                }
            }
            return instance;
        }
        public async Task<string> SaveAsync(HttpPostedFileBase blob)
        {
            CloudBlockBlob blobdowloader = blobContainer.GetBlockBlobReference("Audio - " + Guid.NewGuid() + ".wav");
            using (var stream = blob.InputStream)
            {
                await blobdowloader.UploadFromStreamAsync(stream);
            }
            return blobdowloader.Uri.AbsoluteUri;
        }
        public async Task<bool> DeleteAsync (string bloburi)
        {
            return await blobContainer.GetBlockBlobReference(GetFileName(bloburi)).DeleteIfExistsAsync();
        }
        private string GetFileName(string hrefLink)
        {
            string[] parts = hrefLink.Split('/');
            string fileName = "";
            if (parts.Length > 0)
                fileName = parts[parts.Length - 1];
            else
                fileName = hrefLink;
            return fileName;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}