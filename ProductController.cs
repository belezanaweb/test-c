using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ProdAPI.Models;

namespace ProdAPI.Controllers {
    [RoutePrefix("api")]
    public class ProductController : ApiController {
        
        public static List<Product> productList = new List<Product>();
        
        [HttpPost]
        [Route("Product")]
        public string CreateProduct(Product Product) {

            try { 
                if (productList.Any(n => n.sku == Product.sku)) {
                    throw new ProductException("Erro: Produto já existe.");
                }
                productList.Add(Product);
                return ("Produto cadastrado com sucesso.");
            }

            catch (ProductException e) {
                return (e.Message);
            }
        }

        // PUT: Update Product
        [HttpPut]
        [Route("Product")]
        public string UpdateProduct(Product Product) {
            productList.Where(n => n.sku == Product.sku)
                       .Select(s => { s.sku = Product.sku; s.name = Product.name; return s; })
                       .ToList();

            return "Produto alterado com sucesso.";
        }

        // DELETE: Remove Product
        [HttpDelete]
        [Route("Product/{sku}")]
        public string RemoveProduct(int sku) {
            Product Product = productList.Where(n => n.sku == sku).Select(n => n).First();
            productList.Remove(Product);

            return "Produto excluido com sucesso.";
        }

        // GET: Product by sku
        [HttpGet]
        [Route("Product/{sku}")]
        public Product GetProductBySku(int sku) {
            Product Product = productList.Where(n => n.sku == sku).Select(n => n).FirstOrDefault();
            new Inventory();
            return Product;
        }        
    }
}