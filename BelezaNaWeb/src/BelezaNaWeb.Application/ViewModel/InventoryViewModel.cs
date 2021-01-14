using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Application.ViewModel
{
    public class InventoryViewModel
    {
        public int Quantidade 
        {
            get => Warehouses.Sum(x => x.Quantity);
        }
        public IEnumerable<WarehousesViewModel> Warehouses { get; set; }
    }
}
