using GrupoBoticario.Domain.Entity.Base;
using GrupoBoticario.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBoticario.Domain.Entity.Product
{
    public class WareHouseEntity : ObjectIdAutoGeneratorNumeric
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }

        public string TypeWareHouseId { get; set; }
        
        [NotMapped]
        public EnumTypeWareHouse TypeWareHouse => Enum.Parse<EnumTypeWareHouse>(TypeWareHouseId, true);
    }
}
