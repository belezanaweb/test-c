using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoTest.AppService.Application.Produto.DTO
{
    public class InventoryRequest
    {
        public int Quantidade { get => Warehouses.Sum(x => x.Quantity); }

        public List<WarehouseRequest> Warehouses { get; set; }
    }
}
