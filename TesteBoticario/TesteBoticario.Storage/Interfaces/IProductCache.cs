using System;
using System.Collections.Generic;
using System.Text;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Storage.Interfaces
{
    public interface IProductCache
    {
        Product Get(int sku);
        Product Insert(Product product);
        Product Delete(int sku);
    }
}
