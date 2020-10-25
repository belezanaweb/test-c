using System.Collections.Generic;

namespace Boticario.Backend.Modules.Products.Models
{
    public interface IProductInventory
    {
        long Quantity { get; }
        IList<IProductInventoryDetails> Warehouses { get; }
    }
}
