using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message)
            : base(message)
        {
        }
    }
}
