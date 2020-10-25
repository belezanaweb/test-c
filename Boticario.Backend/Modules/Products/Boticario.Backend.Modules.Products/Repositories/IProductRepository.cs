using Boticario.Backend.Modules.Products.Models;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Repositories
{
    public interface IProductRepository
    {
        Task<IProductEntity> Get(int sku);
        Task Insert(IProductEntity product);
        Task Update(IProductEntity product);
        Task Delete(int sku);
    }
}
