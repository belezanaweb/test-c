using System;

namespace DemoTest.Domain.Entities.Exceptions
{
    public class AtributoObrigatorioExcecao : Exception
    {
        public AtributoObrigatorioExcecao(string campo) : base($"O {campo} é obrigatorio.")
        {
        }
    }
}
