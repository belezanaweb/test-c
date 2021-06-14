using MediatR;
using System;

namespace TesteBoticario.Core.Responses
{
    public class CreateProductResponse : IRequest
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
