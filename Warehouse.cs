using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteProdutoSolange.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
}