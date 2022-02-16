using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Application.Commands.Products.Commom.Dtos
{
    public class InventoryDto
    {
        public int Quantity
        {
            get
            {
                if (Warehouses is null)
                    return 0;

                return Warehouses.Sum(x => x.Quantity);
            }
        }

        public List<WarehouseDto> Warehouses { get; set; }

        public void AddWarehouse(WarehouseDto warehouse)
        {
            if (warehouse is null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            if (Warehouses is null)
            {
                Warehouses = new List<WarehouseDto>();
            }

            if (!Warehouses.Contains(warehouse))
            {
                Warehouses.Add(warehouse);
            }
        }
    }
}
