using System;

namespace Inventory.Core.Exceptions
{
    public class InvalidInventoryException : Exception
    {
        public InvalidInventoryException(long sku)
            : base("Inventory not found, the inventory can not be null to product sku " + sku)
        {

        }
    }
}
