using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBoticario.ViewModels
{
    public class StockKeepingUnitVM
    {

        public StockKeepingUnitVM(StockKeepingUnit sku)
        {
            this.sku = sku.sku;
            this.name = sku.name;
            this.inventory = new InventoryVM(sku.inventory);
            this.isMarketable = inventory.quantity > 0;
        }


        public int sku { get; set; }
        public string name { get; set; }
        public InventoryVM inventory { get; set; }
        public bool isMarketable { get; set; }
    }
}
