using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        
    }
}
