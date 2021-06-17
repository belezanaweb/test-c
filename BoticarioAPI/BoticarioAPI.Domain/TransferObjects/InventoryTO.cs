﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.TransferObjects
{
    public class InventoryTO
    {
        public InventoryTO(int quantity, List<WarehouseTO> warehouses)
        {
            Quantity = quantity;
            Warehouses = warehouses;
        }

        public int Quantity { get; set; }
        public List<WarehouseTO> Warehouses { get; set; }
    }
}
