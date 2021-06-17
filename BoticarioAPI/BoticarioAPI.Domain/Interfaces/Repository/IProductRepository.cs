using BoticarioAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        //bool Add(Product product);
        //bool Update(Product product);
        Product GetBySku(int sku);
        //bool Delete(int sku);
    }
}
