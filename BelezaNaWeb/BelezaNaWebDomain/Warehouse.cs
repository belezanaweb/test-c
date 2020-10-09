using BelezaNaWebDomain.Entities;

namespace BelezaNaWebDomain
{
    public class Warehouse : EntityBase
    {
        public Warehouse()
        {
        }

        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }

        public virtual Inventory Inventory { get; set; }

        public string InventoryId { get; set; }
    }
}