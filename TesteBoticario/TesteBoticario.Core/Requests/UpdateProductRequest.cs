
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Requests
{
    public class UpdateProductRequest : BaseRequest
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }
}
