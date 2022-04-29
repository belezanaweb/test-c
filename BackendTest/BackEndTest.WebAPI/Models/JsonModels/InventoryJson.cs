namespace BackEndTest.WebAPI.Models.JsonModels
{
    public class InventoryJson
    {
        public int Quantity { get; set; }
        public List<WarehouseJson> Warehouses { get; set; }
    }
}
