using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.DTOs.ProductUpdate
{
    public class WarehouseUpdateDTO
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
