using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.TransferObjects
{
    public class NewInventoryTO
    {
        public List<WarehouseTO> Warehouses { get; set; }
    }
}
