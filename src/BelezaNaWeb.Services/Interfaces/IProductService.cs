using BelezaNaWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Services.Interfaces
{
    public interface IProductService
    {
        IList<Product> GetAll();
        Product Find(int sku);
        void Update(int sku, Product product);
        void Delete(int sku);
        void Insert(Product newProduct);
    }
}
