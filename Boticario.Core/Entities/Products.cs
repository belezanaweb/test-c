namespace Boticario.Core.Entities
{
    public class Products
    {
        public Products(int sku, Inventory inventory, bool isMaketable)
        {
            Sku = sku;
            Inventory = inventory;
            IsMarketable = isMaketable;
        }

        public int Sku { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}
