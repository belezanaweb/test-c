
using GrupoBoticario.Domain.Entity.Base;

namespace GrupoBoticario.Domain.Entity.Product
{
    public class ProductEntity : ObjectIdAutoGeneratorNumeric
    {        
        public string Name { get; set; }
        public InventoryEntity Inventory { get; set; } 
    }
}
