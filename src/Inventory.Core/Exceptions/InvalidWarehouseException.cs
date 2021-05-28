using System;

namespace Inventory.Core.Exceptions
{
    public class InvalidWarehouseException : Exception
    {
        public InvalidWarehouseException(long sku)
            : base("Warehouse not found, the warehouse can not be null to product " + sku)
        {

        }
    }
}
