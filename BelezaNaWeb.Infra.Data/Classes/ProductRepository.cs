using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Infra.Data.Classes
{
    public class ProductRepository : IProductRepository
    {
        #region Attributes
        /// <summary>
        /// Create a static List of Products (simulating a database in memory)
        /// </summary>
        private static List<Product> productDatabaseInMemory = new List<Product>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Method that create a new product in the databse
        /// </summary>
        /// <param name="productParam">The new product</param>
        public void Create(Product productParam)
        {
            try
            {
                productDatabaseInMemory.Add(productParam);
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
                if (productDatabaseInMemory.Any(x => x.Sku == sku))
                {
                    productDatabaseInMemory.RemoveAll(x => x.Sku == sku);
                }
                else
                {
                    throw new ArgumentException($"Não existe um produto com o Sku {sku}. Escolha outro valor de Sku e tente novamente");
                }
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
                return productDatabaseInMemory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that gets the product by your Sku code
        /// </summary>
        /// <param name="sku">Sku code</param>
        /// <returns>Selected product</returns>
        public Product GetBySku(int sku)
        {
            try
            {
                return productDatabaseInMemory.FirstOrDefault(x => x.Sku == sku);
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
                if (productDatabaseInMemory.Any(x => x.Sku == productParam.Sku))
                {
                    var index = productDatabaseInMemory.FindIndex(x => x.Sku == productParam.Sku);
                    productDatabaseInMemory[index] = productParam;
                }
                else
                {
                    throw new ArgumentException($"Não existe um produto com o Sku {productParam.Sku}. Escolha outro valor de Sku e tente novamente");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}