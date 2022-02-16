using System.Collections.Generic;

namespace BelezaNaWeb.BuildingBlocks.Responses
{
    public class ErrorResponse
    {
        public string Type { get; set; }

        public string Messsage { get; set; }

        public string TraceId { get; set; }

        public IList<ErrorResponseItem> Errors { get; set; }

        public void AddError(ErrorResponseItem error)
        {
            Errors ??= new List<ErrorResponseItem>();
            Errors.Add(error);
        }
    }
}
