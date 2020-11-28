using BelezaNaWeb.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Net;

namespace BelezaNaWeb.Api.Test
{
    class ProcutosControllerTest
    {

        public ProcutosControllerTest()
        {
            CreateInstanceToTest(12345);
        }

        [SetUp]
        public void Setup()
        {

            
        }
       

        [Test]
        public void AddTest()
        {
            var sku = 43264;
            try
            {
                var produto = GetNewProduct(sku);

                var produtoCriado = CallApi("POST", null, produto);

                Assert.AreEqual(produtoCriado.sku, sku);

            }
            catch (WebException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void GetTest()
        {
            var sku = 12345;
            try
            {

                var produto = CallApi("GET", sku, null);

                Assert.AreEqual(produto.sku, sku);

            }
            catch (WebException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void AddAnExistProduct()
        {
            var sku = 12345;
            try
            {

                var produto = GetNewProduct(sku);

                var produtoCriado = CallApi("POST", null, produto);

                Assert.Fail();

            }
            catch (WebException ex)
            {
                Assert.AreEqual(ex.Message.Contains("Bad Request"), true);
            }
        }

        [Test]
        public void UpdateTest()
        {
            var sku = 12345;
            var novoNome = "Nome alterado teste";
            try
            {

                var produto = GetNewProduct(sku);

                produto.name = novoNome;

                CallApi("PUT", 12345, produto);

                var produtoAlterado = CallApi("GET", sku, null);

                Assert.AreEqual(produtoAlterado.name, novoNome);

            }
            catch (WebException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void DeleteTest()
        {
            var sku = 25896;
            CreateInstanceToTest(sku);
            try
            {

                CallApi("DELETE", sku, null);

                var produtoExcluido = CallApi("GET", sku, null);

                Assert.Fail();

            }
            catch (WebException ex)
            {
                Assert.AreEqual(ex.Message.Contains("Not Found"), true);
            }
        }
        

        private void CreateInstanceToTest(int sku)
        {
            var produto = GetNewProduct(sku);
            CallApi("POST", null, produto);
        }

        private Produto GetNewProduct(int sku)
        {
            var produto = new Produto
            {
                sku = sku,                
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                inventory = new Inventory
                {
                    warehouses = new System.Collections.Generic.List<Warehouse>
                    {
                        new Warehouse { locality = "SP", quantity = 12, type = "ECOMMERCE"},
                        new Warehouse { locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE"}
                    }
                }
            };

            return produto;
        }

        private Produto CallApi(string method, int? sku, Produto produto)
        {
            var apiUrl = "http://localhost/BelezaNaWeb/api/Produtos/";

            var request = (HttpWebRequest)WebRequest.Create(apiUrl + sku);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = method;


            
            if (produto != null)
            {
                var jsonProduto = JsonConvert.SerializeObject(produto);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonProduto);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            Produto retorno = new Produto();

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response != null)
                {
                    if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            string responseBody = reader.ReadToEnd();
                            retorno = JsonConvert.DeserializeObject<Produto>(responseBody);
                        }
                    }                    
                    else if (response.StatusCode == HttpStatusCode.NoContent && method == "DELETE")
                    {
                        retorno =  null;
                    }
                }
            }

            return retorno;
        }

    }
}
