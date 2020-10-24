using Boticario.Backend.Modules.Products.Models;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Repositories
{
    public interface IProductRepository
    {
        Task<bool> Exists(int sku);
        Task<IProduct> Get(int sku);
        Task Save(IProduct product);
        Task Delete(int sku);
    }
}
