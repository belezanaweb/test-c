using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.TransferObjects
{
    public class WarehouseTO
    {
        public WarehouseTO()
        {
        }

        public WarehouseTO(string locality, int quantity, string type)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }

        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
