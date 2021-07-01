using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBoticario.Data
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable
        {
            get
            {
                return Inventory.Quantity > 0 ? true : false;
            }
        }
    }
}