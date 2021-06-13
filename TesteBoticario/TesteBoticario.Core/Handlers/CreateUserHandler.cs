using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;
using TesteBoticario.Core.Services.Interfaces;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Handlers
{
    public class CreateUserHandler : BaseHandler<CreateProductRequest>
    {
        public CreateUserHandler(IMapper mapper, IProductService service) : base(mapper, service) { }

        public override Task<BaseResponse> SafeExecuteHandler(CreateProductRequest request, CancellationToken cancellationToken)
        {
            return CreateProduct(request, cancellationToken);
        }

        public Task<BaseResponse> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request);

            var result = _service.CreateProduct(newProduct);

            if (result.Result != null)
            {
                var productResponse = _mapper.Map<CreateProductResponse>(result.Result);
                productResponse.CreatedAt = DateTime.Now;
                result.AddResult(productResponse);
            }

            return Task.FromResult(result);
        }
    }
}
