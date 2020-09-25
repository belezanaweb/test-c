using System;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.Api.Controllers
{
    public class GenericController : ControllerBase
    {
        #region Protected Read-Only Fields

        protected readonly IMediator _mediator;

        #endregion

        #region Protected Properties

        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }

        #endregion

        #region Constructors

        public GenericController(ILogger logger, IMapper mapper, IMediator mediator)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #endregion
    }
}
