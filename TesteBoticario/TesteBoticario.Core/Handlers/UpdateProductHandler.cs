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
    public class UpdateProductHandler : BaseHandler<UpdateProductRequest>
    {
        public UpdateProductHandler(IMapper mapper, IProductService service) : base(mapper, service) { }

        public override Task<BaseResponse> SafeExecuteHandler(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            return UpdateProduct(request, cancellationToken);
        }

        public Task<BaseResponse> UpdateProduct(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var productToUpdate = _mapper.Map<Product>(request);

            var result = _service.UpdateProduct(productToUpdate);

            if (result.Result != null)
            {
                var productResponse = _mapper.Map<UpdateProductResponse>(result.Result);
                productResponse.UpdatedAt = DateTime.Now;
                result.AddResult(productResponse);
            }

            return Task.FromResult(result);
        }
    }
}
