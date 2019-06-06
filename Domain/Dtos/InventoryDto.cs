using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace Domain.Dtos
{
    [DataContract]
    public class InventoryDto
    {

        public int Quantity => Warehouses.Sum(w => w.Quantity);

        [DataMember(Name = "warehouses")]
        public List<WarehouseDto> Warehouses { get; set; }
    }
}
