using System;

namespace Boticario.Backend.Modules.Products.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        internal ProductNotFoundException() : base(string.Empty)
        {
        }
    }
}
