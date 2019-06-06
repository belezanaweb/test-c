namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public bool IsMarketable
        {
            get
            {
                return Inventory?.Quantity > 0;
            }
        }
    }
}
