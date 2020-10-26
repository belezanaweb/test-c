using Boticario.Backend.Modules.Inventory.Dto;
using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Tests.Mocks
{
    internal class InventoryServiceMock : IInventoryServices
    {
        public IInventoryDetails InventoryDetails { get; set; }
        public bool SaveAllWasCalled { get; private set; }
        public bool DeleteAllWasCalled { get; private set; }

        public InventoryServiceMock()
        {
            this.InventoryDetails = new InventoryDetailsMock() { Warehouses = new List<IInventoryWarehouse>() };
            this.SaveAllWasCalled = true;
            this.DeleteAllWasCalled = true;
        }

        public async Task<IInventoryDetails> GetAll(int sku)
        {
            return await Task.Run(() =>
            {
                return this.InventoryDetails;
            });
        }

        public async Task SaveAll(int sku, InventoryOperationDto inventory)
        {
            await Task.Run(() =>
            {
                this.SaveAllWasCalled = true;
            });
        }

        public async Task DeleteAll(int sku)
        {
            await Task.Run(() =>
            {
                this.DeleteAllWasCalled = true;
            });
        }
    }
}
