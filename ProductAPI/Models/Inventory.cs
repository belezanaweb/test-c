using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public class Inventory
    {
        public Inventory()
        {
            //Warehouses = new List<Warehouse>();
            Warehouses = new Collection<Warehouse>();
        }

        [Key]
        [JsonIgnore]
        public int InventoryId { get; set; }

        [NotMapped]
        [JsonPropertyName("quantity")]
        public int Quantity {
//            get {
//                return this.Warehouses.Sum(x => x.Quantity);
//            }
//?
            get
            {
                int result = 0;
                foreach (Warehouse w in this.Warehouses)
                {
                    result += w.Quantity;
                }
                return result;
            }
        }

        [JsonPropertyName("warehouses")]
        public ICollection<Warehouse> Warehouses { get; set; }
        //public List<Warehouse> Warehouses { get; set; }
    }
}
