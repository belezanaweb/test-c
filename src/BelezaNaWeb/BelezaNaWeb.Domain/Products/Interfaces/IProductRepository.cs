using System.Collections.Generic;
using BelezaNaWeb.Domain.Products.Entities;

namespace BelezaNaWeb.Domain.Products.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Get(long sku);
        void Save(Product product);
        void Delete(long sku);
    }
}
