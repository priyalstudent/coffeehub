namespace CoffeeHub.Api.Contracts.Storage
{
    public interface IImageStorage
    {
        Task<string> UploadAsync(
            Stream fileStream,
            string fileName,
            string contentType);
    }
}
