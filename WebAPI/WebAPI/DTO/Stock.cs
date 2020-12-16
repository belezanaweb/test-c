using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_WebAPI_Demo.Models
{
    public class Stock
    {
        private int quantity = 0;

        [JsonProperty("quantity")]
        public int Quantity
        {
            get { return quantity; }

            set
            {
                Recalcular();
            }
           
        }

        public int Recalcular()
        {
            quantity = 0;
            foreach (var warehouse in warehouses)
            {
                quantity = quantity + warehouse.quantity;
            }

            return quantity;
        }
        public List<Warehouse> warehouses;

        public Stock()
        {
            warehouses = new List<Warehouse>();
        }
    }
}