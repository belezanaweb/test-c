using System.Linq;
using BelezaNaWeb.Domain.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BelezaNaWeb.Api.Extensions
{
    public static class ModelStateExtensions
    {
        #region Extension Methods

        public static ErrorDto ToErrorResponse(this ModelStateDictionary modelState)
        {
            var output = ErrorDto.DefaultBadRequestResponse();

            output.Details = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => new ErrorFieldDto(field: "", value: x.ErrorMessage))
                .ToList();

            return output;
        }

        #endregion
    }
}
