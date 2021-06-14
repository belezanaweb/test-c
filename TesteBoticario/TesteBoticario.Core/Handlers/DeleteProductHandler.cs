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
    public class DeleteProductHandler : BaseHandler<DeleteProductRequest>
    {
        public DeleteProductHandler(IMapper mapper, IProductService service) : base(mapper, service) { }

        public override Task<BaseResponse> SafeExecuteHandler(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            return DeleteProduct(request, cancellationToken);
        }

        public Task<BaseResponse> DeleteProduct(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var sku = request.Sku;

            var result = _service.DeleteProduct(sku);

            if (result.Result != null)
            {
                var productResponse = _mapper.Map<DeleteProductResponse>(result.Result);
                productResponse.DeletedAt = DateTime.Now;
                result.AddResult(productResponse);
            }

            return Task.FromResult(result);
        }
    }
}
