namespace BelezaNaWeb.Domain.Entities.Products
{
    public class Warehouse : EntityBase
    {
        public Warehouse(string locality, int quantity, string type, Inventory inventory)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
            Inventory = inventory;
        }

        public Warehouse()
        {
        }

        public long InventoryId { get; set; }

        public string Locality { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
