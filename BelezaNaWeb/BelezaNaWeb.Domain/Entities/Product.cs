namespace BelezaNaWeb.Domain.Entities
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; }
        public bool IsMarketable { get; }

        public Product(Inventory inventory)
        {
            Inventory = inventory;
            IsMarketable = SetMarketable(inventory);
        }

        private static bool SetMarketable(Inventory inventory) => inventory.Quantity > 0;
    }
}
