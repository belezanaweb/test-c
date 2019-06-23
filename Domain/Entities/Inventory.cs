namespace Domain.Entities
{
    public class Inventory
    {
        public int quantity { get; set; }
        public Warehouse[] warehouses { get; set; }
    }

}
