using System;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Application.ViewModels.Read
{
    public class ProductReadViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryReadViewModel Inventory { get; set; }
        public bool IsMarketable { get; set; }

    }
}
