using BelezaNaWebAPI.Model;

namespace BelezaNaWebAPI.Dto
{
    public class UpdateProduct
    {
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }
    }
}
