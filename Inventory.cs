using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteProdutoSolange.Models;

namespace TesteProdutoSolange.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public List<Warehouse> warehouse { get; set; }
    }
}