using Boticario.Backend.Modules.Inventory.Dto;
using Boticario.Backend.Modules.Inventory.Factories;
using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Repositories;
using Boticario.Backend.Modules.Inventory.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Implementation.Services
{
    public class DefaultInventoryServices : IInventoryServices
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IInventoryFactory inventoryFactory;

        public DefaultInventoryServices(IInventoryRepository inventoryRepository, IInventoryFactory inventoryFactory)
        {
            this.inventoryRepository = inventoryRepository;
            this.inventoryFactory = inventoryFactory;
        }

        public async Task<IList<IInventoryEntity>> GetAll(int sku)
        {
            return (await this.inventoryRepository.GetAll(sku)).OrderBy(p => p.Locality).ThenBy(p => p.Type).ToList();
        }

        public async Task SaveAll(int sku, InventoryOperationDto inventory)
        {
            if (inventory.Warehouses == null || inventory.Warehouses.Count == 0)
            {
                return;
            }

            IList<IInventoryEntity> entities = inventory.Warehouses.Select(p => this.inventoryFactory.Create(p.Locality, p.Quantity, p.Type)).ToList();

            await this.inventoryRepository.SaveAll(sku, entities);
        }

        public async Task DeleteAll(int sku)
        {
            await this.inventoryRepository.DeleteAll(sku);
        }
    }
}
