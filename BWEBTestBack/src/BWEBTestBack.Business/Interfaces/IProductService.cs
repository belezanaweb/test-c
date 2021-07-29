using BWEBTestBack.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BWEBTestBack.Business.Interfaces
{
    public interface IProductService
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int sku);
        Task<Product> Get(int sku);
        Task<List<Product>> GetAll();
    }
}
