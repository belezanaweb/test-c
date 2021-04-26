using System;

namespace DemoTest.Domain.Entities.Exceptions
{
    public class RegraNegocioExcecao : Exception
    {
        public RegraNegocioExcecao(string mensagem) : base(mensagem)
        {
        }
    }
}
