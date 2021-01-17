namespace Product.Domain.Entities
{
    public class Warehouses : Entity
    {
        public Warehouses()
        {

        }

        public Warehouses(string locality, int quantity, string type)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }

        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public Inventory Inventory { get; set; }
        public int InventoryId { get; private set; }
    }
}
