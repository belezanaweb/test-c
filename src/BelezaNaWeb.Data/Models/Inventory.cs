using System.Collections.Generic;

namespace BelezaNaWeb.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public virtual IEnumerable<WareHouse> WareHouses { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}