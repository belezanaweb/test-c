using System.Collections.Generic;

namespace Boticario.BelezaWeb.Application.ViewModels.Product
{
	public class InventoryViewModel
	{
		public int Quantity { get; set; }
		public ICollection<WarehouseViewModel> Warehouses { get; set; }
	}
}
