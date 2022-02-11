using MediatR;
using BelezaWeb.Domain.Models;

namespace BelezaWeb.Domain.Requests
{
    public class DeleteProductRequest : IRequest<Response>
    {
        public int Sku { get; set; }
    }
}
