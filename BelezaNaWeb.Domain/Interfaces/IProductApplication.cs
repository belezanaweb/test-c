using BelezaNaWeb.Domain.Entities;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IProductApplication
    {
        /// <summary>
        /// Method that calculates the quantity of products based in the sum of inventory quantity
        /// </summary>
        /// <param name="product">Product</param>
        void ApplyQuantityRule(Product product);

        /// <summary>
        /// Method that apply the marketable rule in the product based in the quantity of the product
        /// </summary>
        /// <param name="product">Product</param>
        void ApplyMarketableRule(Product product);
        
        /// <summary>
        /// Method that create a new product in the databse
        /// </summary>
        /// <param name="productParam">The new product</param>
        void Create(Product entity);

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
        /// Method that gets the product by your sku code
        /// </summary>
        /// <param name="sku">Sku code</param>
        /// <returns>Product</returns>
        Product GetBySku(int sku);

        /// <summary>
        /// Method that update a product
        /// </summary>
        /// <param name="productParam">The product that will be updated</param>
        void Update(Product entity);
    }
}