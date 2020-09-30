using MediatR;

namespace BelezaWeb.Domain.Model
{
    public class Product : IRequest<string>
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }
    }
}
