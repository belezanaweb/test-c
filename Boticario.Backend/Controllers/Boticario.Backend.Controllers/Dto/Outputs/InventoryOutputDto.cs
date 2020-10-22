namespace Boticario.Backend.Controllers.Dto.Outputs
{
    public class InventoryOutputDto
    {
        public long Quantity { get; set; }
        public WarehouseOutputDto[] Warehouses { get; set; }
    }
}
