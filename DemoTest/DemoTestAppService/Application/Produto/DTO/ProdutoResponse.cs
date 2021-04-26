using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTest.AppService.Application.Produto.DTO
{
    public class ProdutoResponse
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryResponse Inventory { get; set; }
        public bool IsMarkatable
        {
            get => Inventory?.Quantidade > 0;
        }

        public ProdutoResponse()
        {
            Inventory = new InventoryResponse();
        }
    }
}
