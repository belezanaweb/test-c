using BelezaNaWeb.API.Dtos.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.API.Dtos.Product
{
    public class CreateProductDto
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public CreateInventoryDto Inventory { get; set; }
    }
}
