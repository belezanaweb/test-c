using BelezanaWeb.Model;
using System;
using System.Linq.Expressions;

namespace BelezanaWeb.Interface.Service
{
    public interface IProductService
    {
        /// <summary>
        /// Gets the document by the ID.
        /// </summary>
        /// <param name="id">Identifier of the document.</param>
        /// <returns>Returns a list of Product.</returns>
        Result<Product> GetById(long id);

        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns>Returns a list of Product.</returns>
        Result<Product> GetAll();
        Result<Product> GetWithWarehouses();

        /// <summary>
        /// Add/Update a new document.
        /// </summary>
        /// <param name="entity">Entity to add/update.</param>
        ResultBase Save(Product model);

        /// <summary>
        /// Update a new document.
        /// </summary>
        /// <param name="entity">Entity to add/update.</param>
        ResultBase Update(Product model);

        ResultBase Delete(Product model);

        /// <summary>
        /// Gets the document by query.
        /// </summary>
        /// <param name="expression">The query to find items.</param>
        /// <returns>Returns a list of Product.</returns>
        Result<Product> GetBy(Expression<Func<Product, bool>> expression);
    }
}
