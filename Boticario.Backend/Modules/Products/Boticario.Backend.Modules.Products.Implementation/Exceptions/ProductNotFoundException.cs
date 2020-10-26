using Boticario.Backend.Common.Exceptions;
using System;

namespace Boticario.Backend.Modules.Products.Implementation.Exceptions
{
    public class ProductNotFoundException : Exception, IObjectNotFoundException
    {
        internal ProductNotFoundException() : base("Product Not Found!")
        {
        }
    }
}
