using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.application.Models.Comum
{
    public class ProductResponse: BaseResponse
    {
        public int sku { get; set; }
        public string? name { get; set; }
        public InventoryResponse? inventory { get; set; }

        public bool isMarketable { get { return inventory?.quantity > 0; } }
    }
}
