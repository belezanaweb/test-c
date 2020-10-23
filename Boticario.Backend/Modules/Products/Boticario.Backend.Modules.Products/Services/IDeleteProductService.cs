using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Services
{
    public interface IDeleteProductService
    {
        Task Delete(int sku);
    }
}
