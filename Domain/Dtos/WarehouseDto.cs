using System.Runtime.Serialization;

namespace Domain.Dtos
{
    [DataContract]
    public class WarehouseDto
    {
        [DataMember(Name = "locality")]
        public string Locality { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
