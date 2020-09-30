using BelezaWeb.Domain.Model;
using MediatR;

namespace BelezaWeb.Domain.Models
{
    public class ProductInput : IRequest<string>
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        private bool isMarketable { get; set; }
    }
}
