using MediatR;

namespace BelezaWeb.Domain.Model
{
    public class Warehouse : IRequest<string>
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
}
