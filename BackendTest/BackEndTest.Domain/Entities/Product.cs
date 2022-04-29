using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndTest.Domain.Entities
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool isMarketable { get; set; }
        public int InventoryId { get; set; }
        [NotMapped]
        public Inventory Inventory { get; set; }
    }
}
