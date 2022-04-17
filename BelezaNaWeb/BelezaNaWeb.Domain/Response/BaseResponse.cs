using System.Net;

namespace BelezaNaWeb.Domain.Response
{
    public class BaseResponse<TEntity>
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public List<TEntity> Data { get; set; }

        public BaseResponse()
        {
            Data = new List<TEntity>();
        }
    }
}
