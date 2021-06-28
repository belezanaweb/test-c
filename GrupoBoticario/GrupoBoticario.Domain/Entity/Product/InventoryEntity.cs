using GrupoBoticario.Domain.Entity.Base;
using System.Collections.Generic;
using System.Linq;

namespace GrupoBoticario.Domain.Entity.Product
{
    public class InventoryEntity : ObjectIdAutoGeneratorNumeric
    {
        public IEnumerable<WareHouseEntity> WareHouses { get; set; }
    }
}
