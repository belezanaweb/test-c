namespace ProductApi.Models
{
    public class Product
    {
        public int Sku { get; set; }
        public string? Name { get; set; }
        public ProductInventory? Inventory { get; set; }
        public bool IsMarketable => Inventory?.Quantity > 0;
    }
}