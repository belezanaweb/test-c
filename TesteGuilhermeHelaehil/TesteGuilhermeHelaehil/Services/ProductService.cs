using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteGuilhermeHelaehil.Models;

namespace TesteGuilhermeHelaehil.Services
{
    public class ProductService
    {
        //retorna todos os produtos
        public List<Product> GetProducts()
        {
            return MyProducts.ProductsList;
        }

        //Retorna produto por SKU
        public Product FindProduct(int sku)
        {
            return MyProducts.ProductsList.Find(o => o.sku == sku);
        }

        //Cria um produto
        public Product CreateProduct(Product product)
        {
            MyProducts.ProductsList.Add(product);
            return product;
        }

        //Atualiza um produto por SKU
        public Product UpdateProduct(int sku, Product product)
        {
            var indexToUpdate = MyProducts.ProductsList.FindIndex(o => o.sku == sku);
            if(indexToUpdate >= 0)
            {
                MyProducts.ProductsList[indexToUpdate] = product;
            }
            return product;
        }

        //Deleta um produto por SKU
        public int DeleteProduct(int sku)
        {
            return MyProducts.ProductsList.RemoveAll(o => o.sku == sku);
        }
    }
}
