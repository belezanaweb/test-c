using Boticario.Backend.Modules.Products.Dto;
using Boticario.Backend.Modules.Products.Models;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Services
{
    public interface IProductServices
    {
        Task<IProductDetails> Get(int sku);
        Task Create(ProductOperationDto product);
        Task Update(ProductOperationDto product);
        Task Delete(int sku);
    }
}
