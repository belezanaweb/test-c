using BelezaNaWeb.TestC.Api.Models;

namespace BelezaNaWeb.TestC.Api.Data
{
    public interface IProductDao
    {
        void Add(Product product);
        void Delete(uint sku);
        void Edit(uint sku, Product product);
        Product Get(uint sku);
    }
}