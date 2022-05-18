using System.ComponentModel;

namespace Belezanaweb.Domain.Products.Enums
{
    public enum WarehouseType
    {
        [Description("ECOMMERCE")]
        Ecommerce = 1,

        [Description("PHYSICAL_STORE")]
        PhysicalStore = 2
    }
}
