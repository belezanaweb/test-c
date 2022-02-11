using MediatR;

namespace BelezaWeb.Domain.Models
{
    public class Warehouse : IRequest<string>
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
