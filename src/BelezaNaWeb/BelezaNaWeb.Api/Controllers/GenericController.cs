using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.Api.Controllers
{
    public class GenericController : ControllerBase
    {
        #region Protected Properties

        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }

        #endregion

        #region Constructors

        public GenericController(ILogger logger, IMapper mapper)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion
    }
}
