using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Dtos
{
    [DataContract]
    public class ProductCreateDto
    {
        public long Sku { get; set; }

        [DataMember(Name="name")]
        [Required]
        public string Name { get; set; }

        [DataMember(Name="inventory")]
        public InventoryDto Inventory { get; set; }
    }
}
