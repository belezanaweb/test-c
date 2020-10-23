using Boticario.Backend.Modules.Products.Models;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Services
{
    public interface ICreateProductService
    {
        Task Create(int sku, string name);
    }
}
