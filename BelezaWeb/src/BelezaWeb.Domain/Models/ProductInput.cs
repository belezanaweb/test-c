using MediatR;

namespace BelezaWeb.Domain.Models
{
    public class ProductInput : IRequest<string>
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        private bool IsMarketable { get; set; }
    }
}
