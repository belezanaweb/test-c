using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste_Boticario.Models
{
    public class Inventory
    {
        private int quantity;

        public int Quantity
        {
            get
            {
                if (Warehouses != null)
                {
                    return quantity = Warehouses.Sum(x => x.Quantity);
                }

                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        [Required]
        public List<Warehouses> Warehouses { get; set; }
    }
}