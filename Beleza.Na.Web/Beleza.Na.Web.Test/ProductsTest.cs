//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using Beleza.Na.Web.API.Controllers;
//using Beleza.Na.Web.Domain;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Beleza.Na.Web.Test
//{
//    [TestClass]
//    public class ProductsTest
//    {
//        [TestMethod]
//        public void GetProduct_CriaUmProduto()
//        {
//            var produto = new ProductDomain()
//            {
//                Name = "L'Oréal Professionnel",
//                Inventory = new Inventory()
//                {
//                    Warehouses = new List<Warehouse>
//                    {
//                        new Warehouse
//                        {
//                            Locality = "RJ",
//                            Quantity = 156,
//                            Type = "ECOMMERCE"
//                        },
//                         new Warehouse
//                        {
//                            Locality = "SP",
//                            Quantity = 465487,
//                            Type = "PHYSICAL_STORE"
//                        },
//                          new Warehouse
//                        {
//                            Locality = "MG",
//                            Quantity = 65789798,
//                            Type = "ECOMMERCE"
//                        }
//                    }
//                }
//            };

//            var controller = new ProdutoController();
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new System.Web.Http.HttpConfiguration();

//            var result = controller.Post(produto).Result;

//            Assert.AreEqual(result, true);
//        }

//        [TestMethod]
//        public void GetProduct_AtualizarUmProduto()
//        {
//            var produto = new ProductDomain()
//            {
//                Name = "Mudou L'Oréal Professionnel",
//                Inventory = new Inventory()
//                {
//                    Warehouses = new List<Warehouse>
//                    {
//                        new Warehouse
//                        {
//                            Locality = "RJ",
//                            Quantity = 156,
//                            Type = "Mudou ECOMMERCE"
//                        },
//                         new Warehouse
//                        {
//                            Locality = "SP",
//                            Quantity = 465487,
//                            Type = "Mudou PHYSICAL_STORE"
//                        },
//                          new Warehouse
//                        {
//                            Locality = "MG",
//                            Quantity = 65789798,
//                            Type = "ECOMMERCE"
//                        }
//                    }
//                }
//            };

//            var controller = new ProdutoController();
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new System.Web.Http.HttpConfiguration();

//            var result = controller.Put(produto).Result;

//            Assert.AreEqual(result, true);
//        }

//        [TestMethod]
//        public void DeleteProduct_DeletarUmProduto()
//        {
//            var controller = new ProdutoController();
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new System.Web.Http.HttpConfiguration();

//            int sku = 10;

//            var result = controller.Delete(sku).Result;

//            Assert.AreEqual(result, true);
//        }

//        [TestMethod]
//        public void GetProduct_RetornarUmProduto()
//        {
//            var controller = new ProdutoController();
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new System.Web.Http.HttpConfiguration();

//            int sku = 10;

//            var result = controller.Get(sku).Result;

//            Assert.IsNotNull(result);
//        }
//    }
//}
