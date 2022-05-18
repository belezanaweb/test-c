using Boticario.Core.Handlers.Produto;
using Boticario.Core.Model.Commands.Produto;
using Boticario.Tests.Mocks;
using Boticario.Tests.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Tests.Hadnlers.Produto
{
    [TestClass]
    public class ExcluirProdutoHandlerTest
    {
        private readonly ExcluirProdutoHandler _excluirProdutoHandler;

        public ExcluirProdutoHandlerTest()
        {
            _excluirProdutoHandler = new ExcluirProdutoHandler(new UnitOfWorkMock(), new ProdutoRepositoryMock());
        }

        [TestMethod]
        public void ErroSKUNaoExiste()
        {
            var commandResult = _excluirProdutoHandler.Handle(new ExcluirProdutoCommand
            {
                Sku = 12377834
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ExcluidoComSucesso()
        {
            var commandResult = _excluirProdutoHandler.Handle(new ExcluirProdutoCommand
            {
                Sku = 6543
            }, default).Result;

            Assert.IsTrue(commandResult.Sucesso);
        }
    }
}
