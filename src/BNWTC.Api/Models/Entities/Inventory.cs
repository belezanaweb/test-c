using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BNWTC.Api.Models.Entities
{
    public class Inventory
    {
        [Key]
        public int Sku { get; set; }
        public int Quantity
        {
            get
            {
                if (Warehouses == null)
                {
                    return 0;
                }
                else
                {
                    return Warehouses.Sum(x => x.Quantity);
                }
            }
        }
        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}
