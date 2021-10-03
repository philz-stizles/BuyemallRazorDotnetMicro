using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Web.Extensions;
using WebApp.Web.Models;

namespace WebApp.Web.Services.CatalogService
{
    public class CatalogService: ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client, ILogger<CatalogService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetCatalog()
        {
            var response = await _client.GetAsync("/Catalog");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetCatalog(string id)
        {
            var response = await _client.GetAsync($"/Catalog/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<IEnumerable<ProductModel>> GetCatalogByCategory(string category)
        {
            var response = await _client.GetAsync($"/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> CreateCatalog(ProductModel model)
        {
            var response = await _client.PostAsJson($"/Catalog", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
