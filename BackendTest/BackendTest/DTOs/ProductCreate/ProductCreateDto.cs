using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.DTOs.ProductCreate
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public InventoryCreateDto Inventory { get; set; }
    }
}
