using BelezaNaWeb.Domain.Entities;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Repository
{
    public interface IProductRepository
    {
        void CreateProduct(Product productParam);

        void DeleteProductBySkuNumber(int sku);

        IEnumerable<Product> GetAllProducts();

        Product GetBySkuNumber(int sku);

        void UpdateProduct(Product productParam);
    }
}
