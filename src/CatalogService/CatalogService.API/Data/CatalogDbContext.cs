using CatalogService.API.Entities;
using CatalogService.API.Settings;
using MongoDB.Driver;

namespace CatalogService.API.Data
{
    public class CatalogDbContext : ICatalogDbContext
    {

        public CatalogDbContext(ICatalogDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);

            CatalogDbContextSeeder.Seed(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
 