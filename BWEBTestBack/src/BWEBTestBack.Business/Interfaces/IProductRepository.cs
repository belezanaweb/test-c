using BWEBTestBack.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BWEBTestBack.Business.Interfaces
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<Product> GetBySku(int sku);
        Task<List<Product>> GetAll();
        Task Update(Product product);
        Task DeleteBySku(int sku);
    }
}
