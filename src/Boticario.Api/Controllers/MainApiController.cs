using Boticario.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Api.Controllers
{
    [ApiController]
    public class MainApiController : Controller
    {
        #region Attributes

        //private readonly INotificator _notificator;

        #endregion

        #region Constructors

        //public MainApiController(INotificator notificator)
        //{
        //    _notificator = notificator;
        //}

        #endregion

        #region Protected Methods

        protected ActionResult CustomResponse(object result = null)
        {
            if (!ValidOperation())
            {
                return BadRequest(new ResponseViewModel
                {
                    success = false,
                    errors = GetErrors()
                });
            }

            return Ok(new ResponseViewModel
            {
                success = true,
                data = result
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
            //_notificator.AddError(error);
        }

        protected bool ValidOperation()
        {
            return true;
            //return _notificator.GetErrors().Count > 0 ? false : true;
        }

        protected IList<string> GetErrors()
        {
            return null;
            //return _notificator.GetErrors().Select(x => x.Message).ToList();
        }

        #endregion
    }
}