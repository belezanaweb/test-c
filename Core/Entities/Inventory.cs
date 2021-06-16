using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteBelezaNaWeb.API.Core.Entities
{
    public class Inventory
    {
        public Inventory(): base(){}
        [Key]
        public int id { get; private set; }
        public IList<Warehouse> warehouses { get; set; }

    }
}
