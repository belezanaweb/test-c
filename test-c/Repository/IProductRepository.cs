using System;
using System.Collections.Generic;
using testc.Model;

namespace testc.Repository
{
    public interface IProductRepository
    {
        Product Create(Product product);
        Product Update(Product product);
        List<Product> GetAll();
        Product GetBySku(long sku);
        void Delete(long sku);
    }
}
