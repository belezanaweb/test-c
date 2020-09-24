using System.Linq;
using BelezaNaWeb.Api.Contracts.Responses;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BelezaNaWeb.Api.Extensions
{
    public static class ModelStateExtensions
    {
        #region Extension Methods

        public static ErrorResponse ToErrorResponse(this ModelStateDictionary modelState)
        {
            var output = ErrorResponse.DefaultBadRequestResponse();

            output.Details = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => new ErrorField(field: "", value: x.ErrorMessage))
                .ToList();

            return output;
        }

        #endregion
    }
}
