using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.TestC.Api.Exceptions
{
    public class ObjetoJaExistenteNoBDException : ArgumentException
    {
        public ObjetoJaExistenteNoBDException(string message) : base(message) { }
    }
}
