using BackendTest.Domain.Commands.Requests;
using BackendTest.Domain.Commands.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendTest.Domain.Commands.Handlers
{
    public class GetProductBySkuHandler : IRequestHandler<GetProductBySkuRequest, GetProductBySkuResponse>
    {
        private readonly ApiContext _apiContext;

        public GetProductBySkuHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task<GetProductBySkuResponse> Handle(GetProductBySkuRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _apiContext.Products.Include(x => x.Inventory.Warehouses).FirstOrDefault(x => x.Sku == request.Sku);

                if (product == null)
                {
                    return Task.FromResult(GetProductBySkuResponse.NExists());
                }

                return Task.FromResult(GetProductBySkuResponse.Success(product));
            }
            catch (Exception ex)
            {
                return Task.FromResult(GetProductBySkuResponse.Error(ex.InnerException.Message));
            }
        }
    }
}
