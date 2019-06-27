using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteWebApi.Models
{
    public class EstoqueModels
    {
        public int Quantity { get; set; }
        public List<WarehouseModels> WarehouseModels { get; set; }
    }
}