using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class EditProductHandler : GenericHandler<EditProductCommand, bool>
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public EditProductHandler(ILogger<EditProductHandler> logger
            , IMediator mediator
            , IProductRepository productRepository
        )
            : base(logger, mediator)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region Overriden Methods

        public override async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.Get(request.Sku);
            if (result == null)
                throw new ArgumentException($"O produto({request.Sku}) pesquisado não existe.");

            var product = new Product(sku: request.Sku, name: request.Name);

            await _productRepository.Update(request.Sku, product);
            await _productRepository.CompleteAsync();

            return true;
        }

        #endregion
    }
}
