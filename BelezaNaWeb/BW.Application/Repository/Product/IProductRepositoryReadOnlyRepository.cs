using BW.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BW.Application.Repository.Product
{
    public interface IProductRepositoryReadOnlyRepository
    {
        Task<ProductDomain> Get(int sku);
    }
}
