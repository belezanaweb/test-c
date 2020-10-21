namespace Boticario.Domain.Entities
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable => Inventory.Quantity > 0;

        public Product() { }

        public Product(int sku, string name)
        {
            Sku = sku;
            Name = name;
        }
    }
}
