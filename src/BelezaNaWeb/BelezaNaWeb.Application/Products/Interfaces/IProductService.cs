using System.Collections.Generic;
using BelezaNaWeb.Domain.Products.Entities;

namespace BelezaNaWeb.Application.Products.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product Get(long sku);
        void Save(Product product);
        void Update(Product product);
        void Delete(long sku);
    }
}
