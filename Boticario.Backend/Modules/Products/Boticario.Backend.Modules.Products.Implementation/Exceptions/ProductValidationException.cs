using Boticario.Backend.Common.Exceptions;
using System;

namespace Boticario.Backend.Modules.Products.Implementation.Exceptions
{
    public class ProductValidationException : Exception, IBusinessException
    {
        internal ProductValidationException(string message) : base(message)
        {
        }
    }
}
