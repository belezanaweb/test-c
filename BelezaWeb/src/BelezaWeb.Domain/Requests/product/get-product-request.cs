using MediatR;
using BelezaWeb.Domain.Models;

namespace BelezaWeb.Domain.Requests
{
    public class GetProductRequest : IRequest<Response>
    {
        public int Sku { get; set; }
    }
}
