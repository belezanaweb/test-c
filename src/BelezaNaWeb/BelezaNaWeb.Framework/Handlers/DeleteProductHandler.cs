using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Constants;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Domain.Exceptions;
using BelezaNaWeb.Framework.Business;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class DeleteProductHandler : GenericHandler<DeleteProductCommand, bool>
    {
        #region Private Read-Only Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public DeleteProductHandler(ILogger<DeleteProductHandler> logger
            , IMediator mediator
            , IUnitOfWork unitOfWork
            , IProductRepository productRepository
        )
            : base(logger, mediator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region Overriden Methods

        public override async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Sku);
            if (product == null)
                throw new ApiException(ErrorConstants.ProductNotFound.Name, ErrorConstants.ProductNotFound.Message, ErrorConstants.ProductNotFound.Code);

            _productRepository.Delete(product);
            _unitOfWork.Complete();

            return await Task.FromResult(true);
        }

        #endregion
    }
}
