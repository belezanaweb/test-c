using System.Linq;

namespace GBTest.ALC.Domain.Entities
{
    public class InventoryItem
    {
        public decimal Quantity
        {
            get
            {
                if (WareHouses != null && WareHouses.Count > 0)
                    return WareHouses.Sum(_ => _.Quantity);
                return 0.0M;
            }
        }
        public Warehouses WareHouses { get; set; }
    }
}
