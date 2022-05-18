using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boticario.Core.Model.DTOs.Produto
{
    public class ProdutoDTO
    {
        public ProdutoDTO() { }

        public ProdutoDTO(long sku, string name, InventarioDTO inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
        }

        public string Name { get; set; }

        public long Sku { get; set; }

        public InventarioDTO Inventory { get; set; } = new InventarioDTO();

        public bool IsMarketable => Inventory.Quantity > 0;
    }

    public class InventarioDTO
    {
        public int Quantity => Warehouses.Sum(x => x.Quantity);

        public List<EstoqueDTO> Warehouses { get; set; } = new List<EstoqueDTO>();
    }

    public class EstoqueDTO
    {
        public EstoqueDTO() { }

        public EstoqueDTO(string locality, int quantity, string type)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }

        public string Locality { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }
    }
}
