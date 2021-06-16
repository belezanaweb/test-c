using System.ComponentModel.DataAnnotations;


namespace TesteBelezaNaWeb.API.Core.Entities
{
    public class Product
    {
        public Product(int sku, string name)
        {
            this.sku = sku;
            this.name = name;
        }

        [Key]
        public int id { get;  set; }

        public int sku { get; private set; }
        public string name { get; private set; }
        public Inventory inventory { get; set; }
    }
}
