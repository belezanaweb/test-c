using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Services
{
    public interface IDeleteInventoryService
    {
        Task Execute(int sku);
    }
}
