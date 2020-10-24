using System;

namespace Boticario.Backend.Modules.Products.Exceptions
{
    public class ProductAlreadyExistsException : Exception
    {
        internal ProductAlreadyExistsException() : base(string.Empty)
        {
        }
    }
}
