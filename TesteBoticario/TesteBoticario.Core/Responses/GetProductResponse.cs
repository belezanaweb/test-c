using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Responses
{
    public class GetProductResponse : BaseResponse
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}
