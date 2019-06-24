namespace BelezanaWeb.Model
{
    /// <summary>
    /// Message from Product entity.
    /// </summary>  
    public class ProductMessage : BaseEntity
    {
        public ProductMessage()
        {
            Inventory = new InventoryMessage();
        }

        public long Sku  { get; set; }
        public string Name  { get; set; }
        public InventoryMessage Inventory { get; set; }        
    }
}
