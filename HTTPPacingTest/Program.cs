using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;
using System.Diagnostics;

namespace HTTPPacingTest
{
    class Program
    {
        static void Main(string[] args)
        {

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=sdksampleperftest;AccountKey=766sBTnjxC8jyjabbVnlXCpi9i6FRwCATmmBVzXTise0s1xQA4JxznyffBz76WmRajSK437+HgCl4hrv9J02xA==;EndpointSuffix=core.windows.net");

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("tcppacing");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

            Stopwatch _watch = new Stopwatch();

            _watch.Start();

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(@"C:\mysamplefile.1"))
            {
                blockBlob.UploadFromStream(fileStream);
            }

            _watch.Stop();

            Console.WriteLine(_watch.ElapsedMilliseconds);
            long seconds = _watch.ElapsedMilliseconds * 1000;

            Console.WriteLine("Through-put: {0}", (1024 / seconds) / 8);
            Console.ReadKey();

        }

    }
}
