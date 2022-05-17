namespace webapi.domain.Entities
{
    public class Product
    {
        public int sku { get; set; }
        public string? name { get; set; }
        public Inventory? inventory { get; set; }
    }
}