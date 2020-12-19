using System.Collections.Generic;

namespace Boticario.Test.Application.Entity
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}