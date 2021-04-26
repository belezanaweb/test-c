using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTest.AppService.Application.Produto.DTO
{
    public class ProdutoRequest
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryRequest Inventory { get; set; }
        public bool IsMarkatable
        {
            get => Inventory?.Quantidade > 0;
        }
    }
}
