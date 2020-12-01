using Domain.Models;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel GetBySku(long sku);
        bool Create(ProductModel product);
        bool Update(long sku, ProductModel product);
        bool Delete(long sku);
    }
}
