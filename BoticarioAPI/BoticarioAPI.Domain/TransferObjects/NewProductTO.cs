using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.TransferObjects
{
    public class NewProductTO
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public NewInventoryTO Inventory { get; set; }
    }
}
