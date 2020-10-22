namespace Boticario.Backend.Controllers.Dto.Inputs
{
    public class ProductInputDto
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryInputDto Inventory { get; set; }
    }
}
