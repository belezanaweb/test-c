using System.Linq;
using BelezaNaWeb.Api.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BelezaNaWeb.Api.Extensions
{
    public static class ModelStateExtensions
    {
        #region Extension Methods

        public static ErrorResponseDto ToErrorResponse(this ModelStateDictionary modelState)
        {
            var output = ErrorResponseDto.DefaultBadRequestResponse();

            output.Details = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => new ErrorFieldDto(field: "", value: x.ErrorMessage))
                .ToList();

            return output;
        }

        #endregion
    }
}
