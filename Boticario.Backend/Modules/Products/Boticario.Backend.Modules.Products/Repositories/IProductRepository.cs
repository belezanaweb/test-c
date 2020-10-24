using Boticario.Backend.Modules.Products.Models;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Repositories
{
    public interface IProductRepository
    {
        Task<IProduct> Get(int sku);
        Task Insert(IProduct product);
        Task Update(IProduct product);
        Task Delete(int sku);
    }
}
