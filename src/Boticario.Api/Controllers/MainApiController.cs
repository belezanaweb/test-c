using Boticario.Api.ViewModels;
using Boticario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Api.Controllers
{
    [ApiController]
    public class MainApiController : Controller
    {
        #region Properties
        
        private readonly INotificator _notificator;

        #endregion

        #region Constructors

        public MainApiController(INotificator notificator)
        {
            _notificator = notificator;
        }

        #endregion

        #region Protected Methods

        protected ActionResult CustomResponse(object result = null)
        {
            if (!ValidOperation())
            {
                return BadRequest(new ResponseViewModel
                {
                    Success = false,
                    Errors = GetErrors()
                });
            }

            return Ok(new ResponseViewModel
            {
                Success = true,
                Data = result
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) ErrorModelState(modelState);

            return CustomResponse();
        }

        protected void ErrorModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                AddError(errorMsg);
            }
        }

        protected void AddError(string error)
        {
            _notificator.AddError(error);
        }

        protected bool ValidOperation()
        {
            return _notificator.GetErrors().Count <= 0;
        }

        protected IList<string> GetErrors()
        {
            return _notificator.GetErrors().Select(x => x.Message).ToList();
        }

        #endregion
    }
}