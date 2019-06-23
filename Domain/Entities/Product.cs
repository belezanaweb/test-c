namespace Domain.Entities
{
    public class Product
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }
    }

}
