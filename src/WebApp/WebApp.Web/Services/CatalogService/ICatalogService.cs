using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Web.Models;

namespace WebApp.Web.Services.CatalogService
{
    public interface ICatalogService
    {
        Task<IEnumerable<ProductModel>> GetCatalog();
        Task<IEnumerable<ProductModel>> GetCatalogByCategory(string category);
        Task<ProductModel> GetCatalog(string id);
        Task<ProductModel> CreateCatalog(ProductModel model);
    }
}
