using System.Collections.Generic;

namespace Boticario.Backend.Modules.Products.Models
{
    public interface IProductDetails
    {
        int Sku { get; }
        string Name { get; }
        IProductInventory Inventory { get; }
        bool IsMarketable { get; }
    }

    public interface IProductInventory
    {
        long Quantity { get; }
        IList<IProductInventoryDetails> Warehouses { get; }
    }

    public interface IProductInventoryDetails
    {
        string Locality { get; }
        long Quantity { get; }
        string Type { get; }
    }
}
