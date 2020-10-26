using System.Collections.Generic;

namespace Boticario.Backend.Modules.Inventory.Models
{
    public interface IInventoryDetails
    {
        long Quantity { get; }
        IList<IInventoryWarehouse> Warehouses { get; }
    }

    public interface IInventoryWarehouse
    {
        string Locality { get; }
        long Quantity { get; }
        string Type { get; }
    }
}
