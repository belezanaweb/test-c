using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezanaWeb.Model
{
    public class InventoryMessage
    {
        public InventoryMessage()
        {
            Warehouses = new List<WarehouseMessage>();
        }

        public List<WarehouseMessage> Warehouses { get; set; }

        public long Quantity
        {
            get
            {
                var quantity = 0;
                if (this.Warehouses != null && this.Warehouses.Any())
                    quantity = this.Warehouses.Sum(x => x.Quantity);

                return quantity;
            }
        }

        public bool IsMarketable
        {
            get
            {
                var isMarketable = false;
                if (this.Warehouses != null && this.Warehouses.Any())
                    isMarketable = true;

                return isMarketable;
            }
        }
    }

    /// <summary>
    /// Message from Warehouse entity.
    /// </summary>  
    public class WarehouseMessage : BaseEntity
    {   
        public string Locality  { get; set; }
        public int Quantity  { get; set; }
        public string Type  { get; set; }
        public WarehouseMessage WarehousesMessage { get; set; }
    }
}
