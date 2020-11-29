using System.Collections.Generic;

using TestC.Models;

namespace TestC.Services
{
    public interface IProductService
    {
        Product Insert(Product product);
        Product Update(Product product);
        void Delete(int sku);
        Product GetByID(int sku);
        IEnumerable<Product> GetAll();
    }
}