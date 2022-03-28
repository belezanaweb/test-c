using BackendTest.DTOs.ProductCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Service
{
    public interface IProductService
    {
        void RegisterProduct(ProductCreateDto product);
    }
}
