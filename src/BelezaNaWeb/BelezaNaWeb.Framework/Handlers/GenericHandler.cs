using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.Framework.Handlers
{
    public abstract class GenericHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>        
    {
        #region Protected Read-Only Fields

        protected readonly ILogger _logger;
        protected readonly IMediator _mediator;

        #endregion

        #region Constructors

        public GenericHandler(ILogger logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #endregion

        #region Public Abstract Methods

        public abstract Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);

        #endregion
    }
}
