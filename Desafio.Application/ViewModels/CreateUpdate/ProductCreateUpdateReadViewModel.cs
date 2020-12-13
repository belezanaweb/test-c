using System;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Application.ViewModels.CreateUpdate
{
    public class ProductCreateUpdateReadViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryCreateUpdateViewModel Inventory { get; set; }
    }
}
