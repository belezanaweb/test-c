using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Warehouse
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
}