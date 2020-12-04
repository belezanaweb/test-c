

namespace BelezaNaWeb.Data.Models
{
    public class WareHouse
    {
        public int Id { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}