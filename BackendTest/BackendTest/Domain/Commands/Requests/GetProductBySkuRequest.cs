using BackendTest.Domain.Commands.Responses;
using MediatR;

namespace BackendTest.Domain.Commands.Requests
{
    public class GetProductBySkuRequest : IRequest<GetProductBySkuResponse>
    {
        public long Sku { get; set; }
    }
}
