using BelezaNaNet.Api.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelezaNaNet.Api.Models
{
    public class Product
    {
        protected Product() {}
        public Product(double sku, string name, Inventory inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
            IsMarketable = true ? Inventory.Quantity > 0 : false;
        }
        public double Sku { get; private set; }
        public string Name { get; private set; }
        [NotMapped]
        public Inventory Inventory { get; private set; }
        public bool IsMarketable { get; private set; }
        public void Update(string name, Inventory inventory)
        {
            Name = name;
            Inventory = new Inventory(inventory.Warehouses);
            IsMarketable = true ? Inventory.Quantity > 0 : false;
        }
    }
}
