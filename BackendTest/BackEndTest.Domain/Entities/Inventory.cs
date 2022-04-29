using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndTest.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductSku { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public List<Warehouse> Warehouses { get; set; }
    }
}
