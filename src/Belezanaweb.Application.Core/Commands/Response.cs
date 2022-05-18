using Newtonsoft.Json;

namespace Belezanaweb.Application.Core.Commands
{
    public class BaseResponse<TRequest> where TRequest : class
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("errorMessages")]
        public string[] ErrorMessages { get; set; }
        [JsonProperty("data")]
        public TRequest Data { get; set; }
    }

    public class Response<TRequest> : BaseResponse<TRequest> where TRequest : class
    {
        public Response(string errorMessage)
        {
            base.ErrorMessages = new[] { errorMessage } ;
            Success = false;
            Data = default;
        }

        public Response(TRequest data)
        {
            Data = data;
            Success = true;
        }
    }

    public class Response : BaseResponse<object>
    {
        public Response(string errorMessage)
        {
            ErrorMessages = new[] { errorMessage };
            Success = false;
        }

        public Response(string[] errorMessages)
        {
            ErrorMessages = errorMessages;
            Success = false;
        }

        public Response()
        {
            Success = true;
        }
    }
}
