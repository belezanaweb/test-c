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
    public class InserirProdutoHandlerTest
    {
        private readonly InserirProdutoHandler _inserirProdutoHandler;

        public InserirProdutoHandlerTest()
        {
            _inserirProdutoHandler = new InserirProdutoHandler(new UnitOfWorkMock(), new ProdutoRepositoryMock());
        }

        [TestMethod]
        public void ErroNomeVazio()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "",
                Sku = 123778
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeExcedendoLimite()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "543dsfdsfdswwegewgewgweGGwegweGEWGEWGEWGFWEewgewgewgewgwgewGWEGEWgwgewGEWgweGEGEGEWGEWWEGWGEWGWEWfdsfdsafdsgesgwegew",
                Sku = 123778
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeMenosQueMinimo()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "TE",
                Sku = 123778
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroSKUVazio()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 0
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroLocalVazio()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
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
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
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
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
                        {
                            Locality = "E",
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
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
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
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
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
        public void ErroSKUExiste()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 23213,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
                        {
                            Locality = "Teste",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroTipoInvalido()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
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
        public void CadastroComSucesso()
        {
            var commandResult = _inserirProdutoHandler.Handle(new InserirProdutoCommand
            {
                Name = "Teste",
                Sku = 2331,
                Inventory = new InserirProdutoInventarioCommand()
                {
                    Warehouses = new List<InserirProdutoEstoqueCommand>
                    {
                        new InserirProdutoEstoqueCommand
                        {
                            Locality = "RS",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        },
                        new InserirProdutoEstoqueCommand
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
