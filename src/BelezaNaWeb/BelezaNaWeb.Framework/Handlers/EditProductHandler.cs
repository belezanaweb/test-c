using System;
using MediatR;
using System.Linq;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Constants;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Domain.Exceptions;
using BelezaNaWeb.Framework.Business;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class EditProductHandler : GenericHandler<EditProductCommand, bool>
    {
        #region Private Read-Only Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IValidator<EditProductCommand> _commandValidator;

        #endregion

        #region Constructors

        public EditProductHandler(ILogger<EditProductHandler> logger
            , IMediator mediator
            , IUnitOfWork unitOfWork
            , IProductRepository productRepository
            , IValidator<EditProductCommand> commandValidator
        )
            : base(logger, mediator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _commandValidator = commandValidator ?? throw new ArgumentNullException(nameof(commandValidator));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region Overriden Methods

        public override async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            await _commandValidator.ValidateAndThrowAsync(request);

            var exists = await _productRepository.Any(x => x.Sku.Equals(request.Sku));
            if (!exists)
                throw new ApiException(ErrorConstants.ProductNotFound.Name, ErrorConstants.ProductNotFound.Message, ErrorConstants.ProductNotFound.Code);

            var product = new Product(
                  sku: request.Sku
                , name: request.Name
                , warehouses: request.Warehouses
                    .Select(x => new Warehouse(sku: request.Sku, quantity: x.Quantity, locality: x.Locality, type: x.Type))
                    .ToList()
            );

            await _productRepository.Update(request.Sku, product);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return true;
        }

        #endregion
    }
}
