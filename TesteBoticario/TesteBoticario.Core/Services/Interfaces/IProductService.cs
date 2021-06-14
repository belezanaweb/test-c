using System;
using System.Collections.Generic;
using System.Text;
using TesteBoticario.Core.Responses;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Services.Interfaces
{
    public interface IProductService
    {
        BaseResponse GetProduct(int sku);
        BaseResponse CreateProduct(Product product);
        BaseResponse UpdateProduct(Product product);
        BaseResponse DeleteProduct(int sku);
    }
}
