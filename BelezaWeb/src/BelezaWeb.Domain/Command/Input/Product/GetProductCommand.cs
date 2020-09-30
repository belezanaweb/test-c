using BelezaWeb.Domain.Models;
using MediatR;

namespace BelezaWeb.Domain.Command.Input.Product
{
    public class GetProductCommand : IRequest<Response>
    {
        public int sku { get; set; }
    }
}
