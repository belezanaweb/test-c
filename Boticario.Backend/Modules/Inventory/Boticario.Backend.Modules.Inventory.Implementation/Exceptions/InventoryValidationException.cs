using Boticario.Backend.Common.Exceptions;
using System;

namespace Boticario.Backend.Modules.Inventory.Implementation.Exceptions
{
    public class InventoryValidationException : Exception, IBusinessException
    {
        internal InventoryValidationException(string message) : base(message)
        {
        }
    }
}
