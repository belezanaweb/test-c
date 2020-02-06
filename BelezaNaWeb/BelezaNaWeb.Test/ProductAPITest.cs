using BelezaNaWeb.API.Models;
using RestSharp;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace BelezaNaWeb.Test
{
    public class ProductAPITest
    {
        private readonly RestClient _client;
        private Product _defaultProduct;

        public ProductAPITest()
        {
            _client = new RestClient("http://localhost:2723/api/product/");

            _defaultProduct = new Product
            {
                Sku = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",                
                Inventory = new Inventory
                {
                    WareHouses = new List<WareHouse>
                    {
                        new WareHouse
                        {
                            Locality = "SP",
                            Quantity = 1,
                            Type = "ECOMMERCE",
                        },
                        new WareHouse
                        {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE",
                        },
                    },
                },
            };

            //////// Run tests

            CreateOkTest();
            CreateBadRequestTest();

            GetOkTest();
            GetNotFoundTest();

            EditOkTest();
            EditNotFoundTest();

            DeleteOkTest();
            DeleteNotFoundTest();            
        }

        public void CreateOkTest()
        {
            var request = new RestRequest("", Method.POST, DataFormat.Json);
            request.AddJsonBody(_defaultProduct);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception();
        }

        public void CreateBadRequestTest()
        {
            var request = new RestRequest("", Method.POST, DataFormat.Json);
            request.AddJsonBody(_defaultProduct);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.BadRequest)            
                throw new Exception();
        }

        public void GetOkTest()
        {
            var request = new RestRequest("43264", Method.GET);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.OK && !response.Data.Inventory.Quantity.Equals(_defaultProduct.Inventory.WareHouses.Sum(x => x.Quantity)))
                throw new Exception();
        }

        public void GetNotFoundTest()
        {
            var request = new RestRequest("9999", Method.GET);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.NotFound)
                throw new Exception();
        }

        public void EditOkTest()
        {
            var request = new RestRequest("43264", Method.PUT, DataFormat.Json);
            _defaultProduct.Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 750g";
            request.AddJsonBody(_defaultProduct);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.OK && !response.Data.Name.Equals(_defaultProduct.Name))
                throw new Exception();
        }

        public void EditNotFoundTest()
        {
            var request = new RestRequest("43000", Method.PUT, DataFormat.Json);
            request.AddJsonBody(_defaultProduct);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.NotFound)
                throw new Exception();
        }
        
        public void DeleteOkTest()
        {
            var request = new RestRequest("43264", Method.DELETE, DataFormat.Json);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception();
        }

        public void DeleteNotFoundTest()
        {
            var request = new RestRequest("43000", Method.DELETE, DataFormat.Json);
            var response = _client.Execute<Product>(request);
            if (response.StatusCode != HttpStatusCode.NotFound)
                throw new Exception();
        }        
    }
}
