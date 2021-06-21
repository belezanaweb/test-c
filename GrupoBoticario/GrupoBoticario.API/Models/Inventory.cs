using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GrupoBoticario.API.Models
{
    public class Inventory
    {
        [Key]
        public int Sku { get; set; }
        public int Quantity
        {
            get
            {
                return Warehouses is null ? 0 : Warehouses.Sum(x => x.Quantity);                
            }
        }
        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}
