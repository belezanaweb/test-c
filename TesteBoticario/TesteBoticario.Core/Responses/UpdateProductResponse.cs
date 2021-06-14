using MediatR;
using System;

namespace TesteBoticario.Core.Responses
{
    class UpdateProductResponse : IRequest
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsMarketable { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
