using CoffeeHub.Api.Models;
using Microsoft.Azure.Cosmos;

namespace CoffeeHub.Api.Services
{
    public class ContactMessageCosmosService
    {
        private readonly Container _container;

        public ContactMessageCosmosService(IConfiguration config)
        {
            var endpoint = config["Cosmos:Endpoint"];
            var key = config["Cosmos:Key"];
            var dbName = config["Cosmos:Database"];
            var containerName = config["Cosmos:Container"];

            var client = new CosmosClient(endpoint, key);
            var database = client.GetDatabase(dbName);
            _container = database.GetContainer(containerName);
        }

        public async Task AddAsync(ContactMessage msg)
        {
            msg.Id = Guid.NewGuid().ToString();
            await _container.CreateItemAsync(msg,
                new PartitionKey(msg.Id));
        }

        public async Task<List<ContactMessage>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<ContactMessage>(
                "SELECT * FROM c ORDER BY c.createdAt DESC");

            var results = new List<ContactMessage>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }
    }
}