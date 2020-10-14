using Domain.Model;
using System.Collections.Generic;
using System.Linq;
namespace TesteBoticario.ViewModels
{
    public class InventoryVM
    {
        public InventoryVM(Inventory inventory)
        {
            this.quantity = inventory.warehouses.Sum(x => x.quantity);
            this.warehouses = inventory.warehouses.Select(x => new WarehouseVM
            {
                quantity = x.quantity,
                locality = x.locality,
                type = x.type
            }).ToList();
        }
        public int quantity { get; set; }
        public ICollection<WarehouseVM> warehouses { get; set; }

    }
}