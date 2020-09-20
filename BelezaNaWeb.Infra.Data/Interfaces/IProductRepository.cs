using BelezaNaWeb.Domain.Entities;
using System.Collections.Generic;

namespace BelezaNaWeb.Infra.Data.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Method that create a new product in the databse
        /// </summary>
        /// <param name="productParam">The new product</param>
        void Create(Product productParam);

        /// <summary>
        /// Method that delete a product from the database
        /// </summary>
        /// <param name="sku">Sku code of the product that will be deleted</param>
        void Delete(int sku);

        /// <summary>
        /// Method that returns all products from the database
        /// </summary>
        /// <returns>IEnumerable of products</returns>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Method that gets the product by your Sku code
        /// </summary>
        /// <param name="sku">Sku code</param>
        /// <returns>Selected product</returns>
        Product GetBySku(int sku);

        /// <summary>
        /// Method that update a product
        /// </summary>
        /// <param name="productParam">The product that will be updated</param>
        void Update(Product productParam);
    }
}
