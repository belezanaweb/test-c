using Boticario.Backend.Modules.Inventory.Models;
using System;

namespace Boticario.Backend.Modules.Inventory.Tests.Mocks
{
    internal class InventoryEntityMock : IInventoryEntity
    {
        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }
    }
}
