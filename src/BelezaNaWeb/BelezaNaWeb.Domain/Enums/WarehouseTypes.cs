using System.ComponentModel;

namespace BelezaNaWeb.Domain.Enums
{
    public enum WarehouseTypes: int
    {
        [Description("ECOMMERCE")]
        ECommerce,
        [Description("PHYSICAL_STORE")]
        PhysicalStore
    }
}
