using System;
using BelezaNaWeb.Domain.Common.Exceptions;

namespace BelezaNaWeb.Domain.Products.Exceptions
{
    public class ProductWarehouseNotFoundForDeletionException : DomainException
    {
        public ProductWarehouseNotFoundForDeletionException(string message) : base(message)
        {
        }
    }
}
