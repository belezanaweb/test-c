using System.Net;
using System.Text.Json;

namespace BelezaWeb.Infra.ExceptionHandler.Models
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string Message { get; set; } = "Ocorreu uma excessão";

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
