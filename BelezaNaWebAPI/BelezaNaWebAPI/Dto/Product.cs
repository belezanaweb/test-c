using BelezaNaWebAPI.Model;

namespace BelezaNaWebAPI.Dto
{
    public class Product
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
    }
}
