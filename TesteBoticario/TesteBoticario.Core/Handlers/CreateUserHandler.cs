using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Handlers
{
    public class CreateUserHandler : BaseHandler<CreateProductRequest>
    {
        public CreateUserHandler(IMapper mapper) : base(mapper) { }

        public override Task<BaseResponse> SafeExecuteHandler(CreateProductRequest request, CancellationToken cancellationToken)
        {
            return CreateProduct(request, cancellationToken);
        }

        public Task<BaseResponse> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            // validation
            // service.create

            var newProduct = _mapper.Map<Product>(request);

            var product = new CreateProductResponse
            {
                Sku = 1,
                Name = request.Name,
                Quantity = 1,
                IsMarketable = true,
                CreatedAt = DateTime.Now
            };
            var response = new BaseResponse(product, true);

            return Task.FromResult(response);
        }
    }
}
