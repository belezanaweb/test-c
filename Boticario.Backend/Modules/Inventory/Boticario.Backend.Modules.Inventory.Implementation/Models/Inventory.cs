using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Inventory.Implementation.Models
{
    internal class Inventory : IInventory
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
