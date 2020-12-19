using System.ComponentModel.DataAnnotations.Schema;

namespace Boticario.Test.Application.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public virtual Inventory Inventory { get; set; }
        [NotMapped]
        public bool IsMarketable { get; set; }
    }
}