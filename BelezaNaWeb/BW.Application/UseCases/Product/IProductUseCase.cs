using BW.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BW.Application.UseCases.Product
{
    public interface IProductUseCase
    {
        Task<ProductDomain> Get(int sku);
        Task Add(ProductDomain product);
        Task Update(ProductDomain product);
        Task Delete(int sku);
    }
}
