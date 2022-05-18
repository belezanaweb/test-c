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
    public class AtualizarProdutoHandlerTest
    {
        private readonly AtualizarProdutoHandler _atualizarProdutoHandler;

        public AtualizarProdutoHandlerTest()
        {
            _atualizarProdutoHandler = new AtualizarProdutoHandler(new UnitOfWorkMock(), new ProdutoRepositoryMock());
        }

        [TestMethod]
        public void ErroNomeVazio()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "",
                Sku = 123778
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeExcedendoLimite()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "543dsfdsfdswwegewgewgweGGwegweGEWGEWGEWGFWEewgewgewgewgwgewGWEGEWgwgewGEWgweGEGEGEWGEWWEGWGEWGWEWfdsfdsafdsgesgwegew",
                Sku = 123778
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeMenosQueMinimo()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "TE",
                Sku = 123778
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroSKUVazio()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 0
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroLocalVazio()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new AtualizarProdutoInventarioCommand()
                {
                    Warehouses = new List<AtualizarProdutoEstoqueCommand>
                    {
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroLocalExcedendoLimite()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new AtualizarProdutoInventarioCommand()
                {
                    Warehouses = new List<AtualizarProdutoEstoqueCommand>
                    {
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "qwewqewqeqwewqewqewqwqewqewqewqewqewqewqewqewqewqewqewqe",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroLocalMenosQueMinimo()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new AtualizarProdutoInventarioCommand()
                {
                    Warehouses = new List<AtualizarProdutoEstoqueCommand>
                    {
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "ER",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroQuantidadeVazio()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new AtualizarProdutoInventarioCommand()
                {
                    Warehouses = new List<AtualizarProdutoEstoqueCommand>
                    {
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "SP",
                            Quantity = null,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroTipoVazio()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new AtualizarProdutoInventarioCommand()
                {
                    Warehouses = new List<AtualizarProdutoEstoqueCommand>
                    {
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "",
                            Quantity = 3,
                            Type = ""
                        }
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroTipoInvalido()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new AtualizarProdutoInventarioCommand()
                {
                    Warehouses = new List<AtualizarProdutoEstoqueCommand>
                    {
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "RS",
                            Quantity = 3,
                            Type = "PHYSICAL_STORESSSS"
                        }
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void AtualizadoComSucesso()
        {
            var commandResult = _atualizarProdutoHandler.Handle(new AtualizarProdutoCommand
            {
                Name = "Teste",
                Sku = 6543,
                Inventory = new AtualizarProdutoInventarioCommand()
                {
                    Warehouses = new List<AtualizarProdutoEstoqueCommand>
                    {
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "RS",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        },
                        new AtualizarProdutoEstoqueCommand
                        {
                            Locality = "SP",
                            Quantity = 5,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            }, default).Result;

            Assert.IsTrue(commandResult.Sucesso);
        }
    }
}
