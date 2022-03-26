namespace ProductApi.Models
{
    public class ProductInventory
    {
        public ProductInventory()
        {
            Warehouses = new List<ProductWarehouse>();
        }

        public int Quantity => Warehouses.Sum(w => w?.Quantity ?? 0);
        public List<ProductWarehouse> Warehouses { get; set; }
    }
}