using BelezaNaWeb.Domain.Common.Exceptions;

namespace BelezaNaWeb.Domain.Products.Exceptions
{
    public class InvalidProductSkuException : DomainException
    {
        public InvalidProductSkuException(string message) : base (message)
        {
        }
    }
}
