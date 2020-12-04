using BelezaNaWeb.API.Dtos.Inventory;

namespace BelezaNaWeb.API.Dtos.Product
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public CreateInventoryDto Inventory { get; set; }
    }
}
