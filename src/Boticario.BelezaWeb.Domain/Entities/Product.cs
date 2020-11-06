namespace Boticario.BelezaWeb.Domain.Entities
{
	public class Product : Entity
	{
		public int Sku { get; set; }
		public string Name { get; set; }
		public bool IsMarketable =>
			!(Inventory is null) && Inventory.Quantity > 0;

		public virtual Inventory Inventory { get; set; }
	}
}
