using BelezaNaWeb.Domain.Common.Exceptions;

namespace BelezaNaWeb.Domain.Products.Exceptions
{
    public class InvalidProductNameException : DomainException
    {
        public InvalidProductNameException(string message) : base(message)
        {
        }
    }
}
