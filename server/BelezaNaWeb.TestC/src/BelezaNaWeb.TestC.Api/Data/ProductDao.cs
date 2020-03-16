using BelezaNaWeb.TestC.Api.Exceptions;
using BelezaNaWeb.TestC.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.TestC.Api.Data
{
    public class ProductDao : IProductDao
    {
        private readonly IList<Product> products;

        public ProductDao(IBdInMemory bd)
            => products = bd.Products;

        public Product Get(uint sku)
            => products.SingleOrDefault(p => p.Sku == sku);

        public void Add(Product product)
        {
            if (Get(product.Sku) != null)
                throw new ObjetoJaExistenteNoBDException("Já existe um produto com o SKU informado.");

            products.Add(product);
        }

        public void Edit(uint sku, Product product)
        {
            if (Get(sku) == null)
                throw new ObjetoNaoEncontradoNoBDException("Não foi encontrado um objeto com o SKU informado.");

            var productIndex = FindIndex(sku);
            products[productIndex] = product;
        }

        public void Delete(uint sku)
        {
            if (Get(sku) == null)
                throw new ObjetoNaoEncontradoNoBDException("Não foi encontrado um objeto com o SKU informado.");

            var productIndex = FindIndex(sku);
            products.RemoveAt(productIndex);
        }

        private int FindIndex(uint sku)
            => products.Where(p => p.Sku == sku).Select((p, i) => i).Single();
    }
}
