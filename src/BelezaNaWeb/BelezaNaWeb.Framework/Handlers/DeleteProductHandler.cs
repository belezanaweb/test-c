using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Commands;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class DeleteProductHandler : GenericHandler<DeleteProductCommand, bool>
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public DeleteProductHandler(ILogger<DeleteProductHandler> logger
            , IMediator mediator
            , IProductRepository productRepository
        )
            : base(logger, mediator)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region Overriden Methods

        public override async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Sku);
            if (product == null)
                throw new ArgumentException($"O produto({request.Sku}) pesquisado não existe.");

            _productRepository.Delete(product);
            _productRepository.Complete();

            return await Task.FromResult(true);
        }

        #endregion
    }
}
