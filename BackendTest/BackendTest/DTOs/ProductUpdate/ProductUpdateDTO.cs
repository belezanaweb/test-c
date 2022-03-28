using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.DTOs.ProductUpdate
{
    public class ProductUpdateDTO
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryUpdateDTO Inventory { get; set; }
    }
}
