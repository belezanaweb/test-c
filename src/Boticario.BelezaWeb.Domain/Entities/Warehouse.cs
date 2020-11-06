namespace Boticario.BelezaWeb.Domain.Entities
{
	public class Warehouse : Entity
	{
		public int InventoryId { get; set; }
		public string Locality { get; set; }
		public int Quantity { get; set; }
		public string Type { get; set; }
		public virtual Inventory Inventory { get; set; }
	}
}
