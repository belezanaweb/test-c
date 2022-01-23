using System.Collections.Generic;

namespace Boticario.API.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Quantity = CalculateQauntity();

            Warehouses = new List<Warehouse>();
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }

        public int CalculateQauntity()
        {
            int totalQuantity = 0;

            foreach (var item in Warehouses)
            {
                totalQuantity = item.Quantity + item.Quantity;
            }

            return totalQuantity;
        }
    }
}
