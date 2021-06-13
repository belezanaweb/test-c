using System;
using System.Collections.Generic;
using System.Text;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Storage.Interfaces
{
    public interface IProductCache
    {
        Product Insert(Product product);
    }
}
