using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;
using TesteBoticario.Core.Services.Interfaces;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Handlers
{
    public class GetProductHandler : BaseHandler<GetProductRequest>
    {
        public GetProductHandler(IMapper mapper, IProductService service) : base(mapper, service) { }

        public override Task<BaseResponse> SafeExecuteHandler(GetProductRequest request, CancellationToken cancellationToken)
        {
            return GetProduct(request, cancellationToken);
        }

        public Task<BaseResponse> GetProduct(GetProductRequest request, CancellationToken cancellationToken)
        {
            var sku = request.Sku;

            var result = _service.GetProduct(sku);

            if (result.Result != null)
            {
                var productResponse = _mapper.Map<GetProductResponse>(result.Result);
                productResponse.Inventory.Quantity = _service.CalculateInventoryQuantity(productResponse.Inventory.Warehouses);
                productResponse.IsMarketable = _service.ProductIsMarketable(productResponse.Inventory.Warehouses);
                result.AddResult(productResponse);
            }

            return Task.FromResult(result);
        }
    }
}
