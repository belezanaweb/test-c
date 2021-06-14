using MediatR;

namespace TesteBoticario.Core.Requests
{
    public class GetProductRequest : BaseRequest
    {
        public int Sku { get; set; }
    }
}
