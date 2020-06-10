using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_beauty.Models;

namespace web_beauty.Repositories
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<Product> GetBySku(long sku);
        Task Update(Product product);
        Task Delete(long sku);
    }
}
