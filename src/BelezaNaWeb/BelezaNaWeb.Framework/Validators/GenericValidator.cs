using System;
using MediatR;
using FluentValidation;
using BelezaNaWeb.Domain.Commands;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.Framework.Validators
{
    public abstract class GenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICommand
    {
        #region Protected Read-Only Fields

        protected readonly ILogger _logger;

        #endregion

        #region Constructors

        protected GenericValidator(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Configure();
        }

        #endregion

        #region Public Abstract Methods

        public abstract void Configure();

        #endregion
    }
}
