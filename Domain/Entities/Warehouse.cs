using Domain.Entities;

namespace Domain.Entites
{
    public class Warehouse : BaseEntity
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int InventoryId { get; set; }
    }
}
