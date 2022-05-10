using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Product InsertProduct(Product product);
        Product UpdateProduct(int sku, Product product);
        Product GetProduct(int sku);
        bool DeleteProduct(int sku);
    }
}
