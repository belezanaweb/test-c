using System.Collections.Generic;
using Model.Models;

namespace Model.Interfaces.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Get product by Sku.
        /// </summary>
        /// <param name="id">Sku Id</param>
        /// <returns>A <see cref="Product"/> object</returns>
        Product Get(int id);

        /// <summary>
        /// Add a new <see cref="Product"/>.
        /// </summary>
        /// <param name="product"><see cref="Product"/> object</param>
        void Add(Product product);

        /// <summary>
        /// Updates a <see cref="Product"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/> object</param>
        void Update(Product product);

        /// <summary>
        /// Deletes a product by Sku.
        /// </summary>
        /// <param name="id">Sku Id</param>
        void Delete(int id);
    }
}
