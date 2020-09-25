using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Api.Extensions;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Api.Commands.Handlers
{
    public sealed class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        #region Private Read-Only Fields

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public CreateProductHandler(ILogger<CreateProductHandler> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region IRequestHandler Members

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.ConvertRequestToEntity<Product>(request);

            await _productRepository.Create(entity);
            await _productRepository.CompleteAsync();

            return new CreateProductResult
            {
                Sku = entity.Sku,
                Name = entity.Name
            };
        }

        #endregion
    }
}
