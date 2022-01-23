namespace Boticario.API.Models
{
    public class Product
    {
        public Product(int sku, Inventory inventory)
        {
            Sku = sku;
            Inventory = inventory;
            IsMarketable = Marketable();
        }

        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }

        private bool Marketable()
        {
            if (Inventory.Quantity > 0)
                return IsMarketable = true;

            return false;
        }
    }
}
