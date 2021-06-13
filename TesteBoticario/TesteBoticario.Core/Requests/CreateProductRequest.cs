using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Requests
{
    public class CreateProductRequest : BaseRequest
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }
}
