using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Products.Tests.Mocks
{
    internal class InventoryEntityMock : IInventoryEntity
    {
        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }
    }
}
