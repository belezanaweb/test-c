using BelezanaWeb.Interface.Repository;
using BelezanaWeb.Interface.Service;
using BelezanaWeb.Model;
using System;
using System.Linq.Expressions;

namespace BelezanaWeb.Service
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository repository;

        public WarehouseService(IWarehouseRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the document by the ID.
        /// </summary>
        /// <param name="id">Document key.</param>
        /// <returns></returns>
        public Result<Warehouse> GetById(long id)
        {
            var result = new Result<Warehouse>();

            try
            {
                var response = repository.GetById(id);

                result.Success = true;
                result.Objects.Add(response);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to get.";
                result.Error = ex;

                //logService.Insert(ex, "ModelService.GetById");
            }

            return result;
        }

        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns>Documents</returns>
        public Result<Warehouse> GetAll()
        {
            var result = new Result<Warehouse>();

            try
            {
                var response = repository.GetAll();

                result.Success = true;
                result.Objects.AddRange(response);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to get.";
                result.Error = ex;

                //logService.Insert(ex, "ModelService.GetAll");
            }

            return result;
        }

        /// <summary>
        /// Get the documents by query.
        /// </summary>
        /// <param name="expression">The query expression.</param>
        /// <returns>Returns a list of Warehouse.</returns>
        public Result<Warehouse> GetBy(Expression<Func<Warehouse, bool>> expression)
        {
            var result = new Result<Warehouse>();

            try
            {
                var response = repository.GetBy(expression);

                result.Success = true;
                result.Objects.AddRange(response);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to get.";
                result.Error = ex;

                //logService.Insert(ex, "ModelService.GetById");
            }

            return result;
        }

	 /// <summary>
        /// Add/Update a document.
        /// </summary>
        /// <param name="model">Model to add/update.</param>
        public ResultBase Save(Warehouse model)
        {
            var result = new Result<Warehouse>();

            try
            {
                repository.Save(model);
                result.Success = true;
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to complete save.";
                result.Error = ex;

                //logService.Insert(ex, "ModelService.Update");
            }

            return result;
        }
    }
}

