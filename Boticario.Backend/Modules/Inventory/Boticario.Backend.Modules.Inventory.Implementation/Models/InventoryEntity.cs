using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Inventory.Implementation.Models
{
    internal class InventoryEntity : IInventoryEntity
    {
        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }
    }
}
