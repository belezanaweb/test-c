using System;
using System.Collections.Generic;
using System.Linq;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Infra.Data.Interfaces;

namespace BelezaNaWeb.Application
{
    public class ProductApplication : IProductApplication
    {
        #region Attributes
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructors
        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method that calculates the quantity of products based in the sum of inventory quantity
        /// </summary>
        /// <param name="product">Product</param>
        public void ApplyQuantityRule(Product product)
        {
            try
            {
                if (product?.Inventory != null && product.Inventory.Warehouses.Any())
                {
                    product.Inventory.Quantity = product.Inventory.Warehouses.Sum(x => x.Quantity);

                    ApplyMarketableRule(product);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that apply the marketable rule in the product based in the quantity of the product
        /// </summary>
        /// <param name="product">Product</param>
        public void ApplyMarketableRule(Product product)
        {
            try
            {
                if (product.Inventory.Quantity > 0)
                    product.IsMarketable = true;
                else
                    product.IsMarketable = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that create a new product in the databse
        /// </summary>
        /// <param name="productParam">The new product</param>
        public void Create(Product productParam)
        {
            try
            {
                if (productParam.Sku < 1)
                    throw new ArgumentException("Sku deve ser um valor entre 1 e 2147483647");

                if (string.IsNullOrEmpty(productParam.Name))
                    throw new ArgumentException("Campo Name é obrigatório");

                var product = _productRepository.GetBySku(productParam.Sku);

                if (product != null)
                    throw new ArgumentException($"Já existe um produto com o Sku {productParam.Sku}. Escolha outro valor de Sku e tente novamente");

                _productRepository.Create(productParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that delete a product from the database
        /// </summary>
        /// <param name="sku">Sku code of the product that will be deleted</param>
        public void Delete(int sku)
        {
            try
            {
                _productRepository.Delete(sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that returns all products from the database
        /// </summary>
        /// <returns>IEnumerable of products</returns>
        public IEnumerable<Product> GetAll()
        {
            try
            {
                var products = _productRepository.GetAll();

                foreach (var item in products)
                    ApplyQuantityRule(item);

                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that gets the product by your sku code
        /// </summary>
        /// <param name="sku">Sku code</param>
        /// <returns>Product</returns>
        public Product GetBySku(int sku)
        {
            try
            {
                var product = _productRepository.GetBySku(sku);
                ApplyQuantityRule(product);

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that update a product
        /// </summary>
        /// <param name="productParam">The product that will be updated</param>
        public void Update(Product productParam)
        {
            try
            {
                _productRepository.Update(productParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}