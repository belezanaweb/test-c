namespace Boticario.Backend.Controllers.Dto.Outputs
{
    public class ProductOutputDto
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryOutputDto Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}
