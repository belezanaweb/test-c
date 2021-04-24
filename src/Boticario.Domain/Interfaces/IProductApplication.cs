using Boticario.Domain.Entities;
using System.Collections.Generic;

namespace Boticario.Domain.Interfaces
{
    public interface IProductApplication
    {
        IList<Product> GetAll();

        Product GetBySku(uint sku);

        Product Create(Product product);

        Product Update(Product product);

        bool DeleteBySku(uint sku);
    }
}