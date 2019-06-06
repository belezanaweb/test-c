using System.Runtime.Serialization;

namespace Domain.Dtos
{
    [DataContract]
    public class ProductListDto
    {

        [DataMember(Name = "sku")]
        public long Sku { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "inventory")]
        public InventoryListDto Inventory { get; set; }

        [DataMember(Name = "isMarketable")]
        public bool IsMarketable { get; set; }
    }
}
