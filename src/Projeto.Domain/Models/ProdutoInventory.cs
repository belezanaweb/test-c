using System.Collections.Generic;
using System.Linq;

namespace Projeto.Domain.Models
{
    public class ProdutoInventory
    {
        public int Sku { get; set; }

        public string Nome { get; set; }

        public int Quantity { get => Warehouses == null ? 0 : Warehouses.Sum(w => w.Quantity); }

        public bool IsMarketable { get => Quantity > 0; }

        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}
