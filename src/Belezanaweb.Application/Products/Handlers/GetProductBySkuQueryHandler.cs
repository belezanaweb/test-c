using AutoMapper;
using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Products.Queries;
using Belezanaweb.Application.Products.ViewModels;
using Belezanaweb.Core.Exceptions;
using Belezanaweb.Domain.Products.Entity;
using Belezanaweb.Domain.Products.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Belezanaweb.Application.Products.Handlers
{
    public class GetProductBySkuQueryHandler : ProductHandlerBase, IRequestHandler<GetProductBySkuQuery, Response<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductBySkuQueryHandler(IProductRepository productRepository, IMapper mapper) 
            : base(productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<Response<ProductViewModel>> Handle(GetProductBySkuQuery request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ValidatorException(request.ValidationResult);

            Product product = base.GetProductBySku(request.Sku);    

            return Task.FromResult(new Response<ProductViewModel>(_mapper.Map<ProductViewModel>(product)));
        }
    }
}
