using System;

namespace BelezaNaWeb.CrossCutting
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() : base()
        {
        }

        public AlreadyExistsException(string message) : base(message) 
        {
        }

        public AlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
