namespace belezanaweb.Domain.Entities
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int InventoryId { get; set; }
        public bool IsMarketable
        {
            get
            {
                return (this.Inventory != null && this.Inventory.Quantity > 0);
            }
        }
    }
}
