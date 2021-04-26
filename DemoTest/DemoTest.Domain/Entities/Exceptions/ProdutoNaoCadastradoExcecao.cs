using System;

namespace DemoTest.Domain.Entities.Exceptions
{
    public class ProdutoNaoCadastradoExcecao : Exception
    {
        public ProdutoNaoCadastradoExcecao() : base("Produto não cadastrado.")
        {
        }
    }
}
