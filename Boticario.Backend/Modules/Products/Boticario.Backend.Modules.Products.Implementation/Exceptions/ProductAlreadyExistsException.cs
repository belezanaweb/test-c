using Boticario.Backend.Common.Exceptions;
using System;

namespace Boticario.Backend.Modules.Products.Implementation.Exceptions
{
    public class ProductAlreadyExistsException : Exception, IBusinessException
    {
        internal ProductAlreadyExistsException() : base("Product Already Exists!")
        {
        }
    }
}
