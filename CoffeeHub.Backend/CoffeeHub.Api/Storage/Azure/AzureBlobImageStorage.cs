using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CoffeeHub.Api.Contracts.Storage;
using CoffeeHub.Api.Storage.Options;
using Microsoft.Extensions.Options;

namespace CoffeeHub.Api.Storage.Azure
{
    public class AzureBlobImageStorage : IImageStorage
    {
        private readonly BlobContainerClient _container;

        public AzureBlobImageStorage(IOptions<ImageStorageOptions> options)
        {
            var blobServiceClient =
                new BlobServiceClient(options.Value.ConnectionString);

            _container =
                blobServiceClient.GetBlobContainerClient(
                    options.Value.ContainerName);

            _container.CreateIfNotExists(PublicAccessType.Blob);
        }

        public async Task<string> UploadAsync(
            Stream fileStream,
            string fileName,
            string contentType)
        {
            var blobClient = _container.GetBlobClient(fileName);

            await blobClient.UploadAsync(
                fileStream,
                new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = contentType
                    }

                });
            return blobClient.Uri.ToString();

        }
    }
}
