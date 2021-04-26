using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoTest.AppService.Application.Produto.DTO
{
    public class InventoryResponse
    {
        public int Quantidade { get => Warehouses.Sum(x => x.Quantity); }

        public List<WarehouseResponse> Warehouses { get; set; }

        public InventoryResponse()
        {
            Warehouses = new List<WarehouseResponse>();
        }
    }
}
