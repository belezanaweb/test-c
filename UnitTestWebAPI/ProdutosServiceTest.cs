using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_Produto.Models;
using WebAPI_Produto.Service;

namespace UnitTestWebAPI
{
    [TestClass]
    public class ProdutosServiceTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var ProdutoSamples = new List<Produto>();
            ProdutoSamples.Add(new Produto()
            {
                sku = 43264,
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                inventory = new Inventory()
                {
                    warehouses = new List<Warehouse>
                    {
                        new Warehouse{
                            locality = "SP", quantity = 12, type = "ECOMMERCE"
                        },
                        new Warehouse{
                            locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE"
                        }
                    }
                }
            });
        }
        [TestMethod]
        public void ShouldPostProduto()
        {
            var _service = new ProdutoService();

            var newProduto = new Produto()
            {
                sku = 43264,
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                inventory = new Inventory()
                {
                    warehouses = new List<Warehouse>
                    {
                        new Warehouse{
                            locality = "SP", quantity = 12, type = "ECOMMERCE"
                        },
                        new Warehouse{
                            locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE"
                        }
                    }
                }
            };

            var result = _service.CriaProduto(newProduto);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldPutProduto()
        {
            var _service = new ProdutoService();

            var newProduto = new Produto()
            {
                sku = 43264,
                name = "Condicionador Dove",
                inventory = new Inventory()
                {
                    warehouses = new List<Warehouse>
                    {
                        new Warehouse{
                            locality = "SP", quantity = 12, type = "ECOMMERCE"
                        },
                        new Warehouse{
                            locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE"
                        }
                    }
                }
            };

            var Oldresult = _service.GetProduto(43264);

            var result = _service.AtualizaProduto(43264, newProduto);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(Oldresult.name, result.name);
        }


        [TestMethod]
        public void ShouldAllGetProdutos()
        {
            var _service = new ProdutoService();

            var result = _service.GetProduto();
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldGetProdutos()
        {
            var _service = new ProdutoService();

            var result = _service.GetProduto(43264);

            Assert.IsNotNull(result);
        }       

        [TestMethod]
        public void ShouldDeletProdutos()
        {
            var _service = new ProdutoService();

            var result = _service.RemoveProduto(43264);
            
            Assert.IsTrue(result);
        }

    }
}
