using BelezaNaWeb.Domain.Entities;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IProductApplication
    {
        void CalcInvetoryQuantity(Product product);

        void VerifyIfIsMarketable(Product product);
        
        void CreateProduct(Product entity);

        void DeleteProductBySkuNumber(int sku);
        
        IEnumerable<Product> GetAllProducts();

        Product GetProductBySku(int sku);

        void UpdateProduct(Product entity);
    }
}