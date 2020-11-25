using System.Linq;

namespace GBTest.ALC.Domain.Entities
{
    public class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable
        {
            get
            {
                return (Inventory != null && Inventory.Count > 0 && Inventory.Sum(_ => _.Quantity) > 0);
            }
        }
    }
}