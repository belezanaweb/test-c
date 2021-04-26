using System;

namespace DemoTest.Domain.Entities.Exceptions
{
    public class ProdutoJaCadastradoExcecao : Exception
    {
        public ProdutoJaCadastradoExcecao() : base("Produto já cadastrado.")
        {
        }
    }
}
