using BelezaWeb.Domain.Models;
using MediatR;

namespace BelezaWeb.Domain.Command.Input.AddProduct
{
    public class DeleteProductCommand : IRequest<Response>
    {
        public int Sku { get; set; }
    }
}
