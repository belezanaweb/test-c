using System.Collections.Generic;
using System.Linq;

namespace Boticario.BelezaWeb.Domain.Entities
{
	public class Inventory : Entity
	{
		public int Quantity
		{
			get
			{
				return Warehouses?.Count > 0
					? Warehouses.Count(w => w.Quantity > 0)
					: 0;
			}
		}

		public int ProductSku { get; set; }
		public virtual Product Product { get; set; }
		public virtual ICollection<Warehouse> Warehouses { get; set; }
	}
}
