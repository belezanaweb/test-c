using BackendTest.Domain.Commands.Responses;
using MediatR;

namespace BackendTest.Domain.Commands.Requests
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public long Sku { get; set; }
    }
}
