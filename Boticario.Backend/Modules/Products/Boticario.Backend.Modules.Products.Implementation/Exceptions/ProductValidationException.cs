using System;

namespace Boticario.Backend.Modules.Products.Implementation.Exceptions
{
    public class ProductValidationException : Exception
    {
        internal ProductValidationException(string message) : base(message)
        {
        }
    }
}
