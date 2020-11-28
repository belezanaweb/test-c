using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int sku { get; set; }

        [Required]
        public string name { get; set; }
        public Inventory inventory { get; set; } = new Inventory();


        public bool isMarketable
        {
            get { return inventory.quantity > 0; }            
        }


    }
}
