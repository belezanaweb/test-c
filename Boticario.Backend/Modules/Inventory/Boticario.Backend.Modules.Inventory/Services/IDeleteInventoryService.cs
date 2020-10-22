using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Services
{
    public interface IDeleteProductInventoryService
    {
        Task Execute(int sku);
    }
}
