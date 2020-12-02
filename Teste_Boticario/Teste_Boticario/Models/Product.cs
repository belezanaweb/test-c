using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste_Boticario.Models
{
    public class Product
    {
        [Required]
        public int Sku { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Inventory Inventory { get; set; }

        private bool isMarketable;

        public bool MyProperty
        {
            get
            {
                if (Inventory != null)
                {
                    return isMarketable = Inventory.Quantity > 0 ? true : false;
                }

                return isMarketable;
            }
            set
            {
                isMarketable = value;
            }
        }
    }
}