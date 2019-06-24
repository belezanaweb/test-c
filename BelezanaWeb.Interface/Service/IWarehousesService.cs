using BelezanaWeb.Model;
using System;
using System.Linq.Expressions;

namespace BelezanaWeb.Interface.Service
{
    public interface IWarehouseService
    {
        /// <summary>
        /// Gets the document by the ID.
        /// </summary>
        /// <param name="id">Identifier of the document.</param>
        /// <returns>Returns a list of Warehouse.</returns>
        Result<Warehouse> GetById(long id);

        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns>Returns a list of Warehouse.</returns>
        Result<Warehouse> GetAll();

        /// <summary>
        /// Add/Update a new document.
        /// </summary>
        /// <param name="entity">Entity to add/update.</param>
        ResultBase Save(Warehouse model);

 	 /// <summary>
        /// Gets the document by query.
        /// </summary>
        /// <param name="expression">The query to find items.</param>
        /// <returns>Returns a list of Warehouse.</returns>
        Result<Warehouse> GetBy(Expression<Func<Warehouse, bool>> expression);
    }
}
