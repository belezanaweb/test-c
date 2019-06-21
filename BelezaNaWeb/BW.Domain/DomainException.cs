using System;
using System.Collections.Generic;
using System.Text;

namespace BW.Domain
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}
