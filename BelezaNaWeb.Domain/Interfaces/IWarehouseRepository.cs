using BelezaNaWeb.Domain.Models;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IWarehouseRepository: IRepository<Warehouse>
    {
        Warehouse Get(string locality, string type);
    }
}
