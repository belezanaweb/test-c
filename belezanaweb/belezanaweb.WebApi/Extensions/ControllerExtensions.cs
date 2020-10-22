using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace belezanaweb.WebApi.Extensions
{
    public static class ControllerExtensions
    {
        public static List<ModelError> ModelStateErrors(this Controller controller, ModelStateDictionary modelState)
        {
            return modelState.Where(a => a.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList();
        }
    }
}
