namespace BackEndTest.WebAPI.Models.JsonModels
{
    public class ProductJson
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool isMarketable { get; set; }
        public InventoryJson Inventory { get; set; }
    }
}
