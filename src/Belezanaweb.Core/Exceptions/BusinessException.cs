using System;

namespace Belezanaweb.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
