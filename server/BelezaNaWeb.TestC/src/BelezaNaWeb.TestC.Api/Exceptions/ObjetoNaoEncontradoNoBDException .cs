using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.TestC.Api.Exceptions
{
    public class ObjetoNaoEncontradoNoBDException : ArgumentException
    {
        public ObjetoNaoEncontradoNoBDException (string message) : base(message) { }
    }
}
