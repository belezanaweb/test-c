using System;
using MediatR;

namespace TesteBoticario.Core.Responses
{
    public class DeleteProductResponse : IRequest
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
