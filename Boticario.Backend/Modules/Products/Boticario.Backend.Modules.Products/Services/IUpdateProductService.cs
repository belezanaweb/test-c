using Boticario.Backend.Modules.Products.Models;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Services
{
    public interface IUpdateProductService
    {
        Task Update(int sku, string name);
    }
}
