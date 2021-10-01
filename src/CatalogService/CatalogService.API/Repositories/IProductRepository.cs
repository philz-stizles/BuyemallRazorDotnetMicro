﻿using CatalogService.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(string id);

        Task<IEnumerable<Product>> GetProductByName( string name);

        Task<IEnumerable<Product>> GetProductByCategory(string category);

        Task Create(Product product);

        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}
