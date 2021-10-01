using CatalogService.API.Entities;
using MongoDB.Driver;

namespace CatalogService.API.Data
{
    public interface ICatalogDbContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
