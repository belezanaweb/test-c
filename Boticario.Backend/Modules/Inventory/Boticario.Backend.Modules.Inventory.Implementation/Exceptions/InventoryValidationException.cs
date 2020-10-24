using System;

namespace Boticario.Backend.Modules.Inventory.Implementation.Exceptions
{
    public class InventoryValidationException : Exception
    {
        internal InventoryValidationException(string message) : base(message)
        {
        }
    }
}
