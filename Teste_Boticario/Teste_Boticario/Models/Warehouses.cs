using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste_Boticario.Models
{
    public class Warehouses
    {
        [Required]
        public string Locality { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Type { get; set; }
    }
}