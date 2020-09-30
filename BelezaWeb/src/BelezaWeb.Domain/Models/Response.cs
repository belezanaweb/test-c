namespace BelezaWeb.Domain.Models
{
    public class Response
    {
        public Response(object data, bool hasError = false)
        {
            Data = data;
            HasError = hasError;
        }

        public bool HasError { get; set; }
        public object Data { get; set; }
    }
}
