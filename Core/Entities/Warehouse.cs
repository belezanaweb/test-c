using System.ComponentModel.DataAnnotations;

namespace TesteBelezaNaWeb.API.Core.Entities
{
    public class Warehouse
    {
        public Warehouse( string locality, int quantity, string type)
        {
            this.locality = locality;
            this.quantity = quantity;
            this.type = type;

        }

        [Key]
        public int id { get;  set; }
        public string locality { get; private set; }
        public int quantity { get; private  set; }
        public string type { get; private set; }
    }
}
