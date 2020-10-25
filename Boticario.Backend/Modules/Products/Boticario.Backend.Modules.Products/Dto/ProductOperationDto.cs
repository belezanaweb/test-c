using Boticario.Backend.Modules.Inventory.Dto;

namespace Boticario.Backend.Modules.Products.Dto
{
    public class ProductOperationDto
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryOperationDto Inventory { get; set; }
    }
}
