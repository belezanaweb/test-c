using Boticario.Backend.Modules.Inventory.Dto;

namespace Boticario.Backend.Modules.Products.Dto
{
    public class ProductOperationDto
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryOperationDto Inventory { get; set; }
    }
}
