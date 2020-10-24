using System;

namespace Boticario.Backend.Modules.Products.Implementation.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        internal ProductNotFoundException() : base(string.Empty)
        {
        }
    }
}
