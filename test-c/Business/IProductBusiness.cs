using System;
using System.Collections.Generic;
using testc.Model;

namespace testc.Business
{
    public interface IProductBusiness
    {
        Product Create(Product product);
        Product Update(Product product);
        List<Product> GetAll();
        Product GetBySku(long sku);
        void Delete(long sku);
    }
}
