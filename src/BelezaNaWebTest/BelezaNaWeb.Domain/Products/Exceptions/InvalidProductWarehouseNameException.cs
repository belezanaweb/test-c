using BelezaNaWeb.Domain.Common.Exceptions;

namespace BelezaNaWeb.Domain.Products.Exceptions
{
    public class InvalidProductWarehouseNameException : DomainException
    {
        public InvalidProductWarehouseNameException(string message) : base(message)
        {
        }
    }
}
