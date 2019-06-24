using BelezanaWeb.Interface.Repository;
using BelezanaWeb.Interface.Service;
using BelezanaWeb.Model;
using BelezanaWeb.Model.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BelezanaWeb.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IWarehouseRepository warehouseRepository;

        public ProductService(IProductRepository repository, IWarehouseRepository warehouseRepository)
        {
            this.repository = repository;
            this.warehouseRepository = warehouseRepository;
        }

        /// <summary>
        /// Gets the document by the ID.
        /// </summary>
        /// <param name="id">Document key.</param>
        /// <returns></returns>
        public Result<Product> GetById(long id)
        {
            var result = new Result<Product>();

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
        public Result<Product> GetWithWarehouses()
        {
            var result = new Result<Product>();

            try
            {
                var response = repository.GetWithWarehouses();

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
        /// Gets all documents.
        /// </summary>
        /// <returns>Documents</returns>
        public Result<Product> GetAll()
        {
            var result = new Result<Product>();

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
        /// <returns>Returns a list of Product.</returns>
        public Result<Product> GetBy(Expression<Func<Product, bool>> expression)
        {
            var result = new Result<Product>();

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
        public ResultBase Save(Product model)
        {
            var result = new Result<Product>();

            try
            {
                var productResponse = repository.GetBy(x => x.Sku == model.Sku && x.Active == true);
                if (productResponse.Any())
                {
                    result.Success = false;
                    result.FriendlyMessage = string.Format("Sku '{0}' already exists!", model.Sku);
                    return result;
                }

                model.Active = true;
                if (model.Warehouses.Any())
                {
                    model.Warehouses = model.Warehouses.Select(x =>
                    {
                        x.Active = true;
                        return x;
                    }).ToList();
                }

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

        /// <summary>
        /// Add/Update a document.
        /// </summary>
        /// <param name="model">Model to add/update.</param>
        public ResultBase Update(Product model)
        {
            var result = new Result<Product>();

            try
            {
                var productResponse = repository.GetWithWarehouses(x => x.Sku == model.Sku && x.Active == true);
                if (!productResponse.Any())
                {
                    result.Success = false;
                    result.FriendlyMessage = string.Format("Sku '{0}' not found", model.Sku);
                    return result;
                }

                var product = productResponse.FirstOrDefault();
                if (product.Warehouses != null && product.Warehouses.Any())
                {
                    foreach (var item in product.Warehouses)
                    {
                        //item.Active = false;
                        //arehouseRepository.Save(item);
                        warehouseRepository.Remove(item);
                    }
                }

                

                model.Id = product.Id;
                model.Active = true;
                if (model.Warehouses != null && model.Warehouses.Any())
                {
                    var items = model.Warehouses.Clone();
                    foreach (var item in items)
                    {
                        item.Active = true;
                        item.ProductId = model.Id;
                        item.Product = model;
                        warehouseRepository.Save(item);
                    }

                    //model.Warehouses = model.Warehouses.Select(x =>
                    //{
                    //    x.Active = true;
                    //    //x.ProductId = model.Id;
                    //    return x;
                    //}).ToList();
                }

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

        /// <summary>
        /// Add/Update a document.
        /// </summary>
        /// <param name="model">Model to add/update.</param>
        public ResultBase Delete(Product model)
        {
            var result = new Result<Product>();

            try
            {
                var productResponse = repository.GetWithWarehouses(x => x.Sku == model.Sku && x.Active == true);
                if (!productResponse.Any())
                {
                    result.Success = false;
                    result.FriendlyMessage = string.Format("Sku '{0}' not found", model.Sku);
                    return result;
                }

                var product = productResponse.FirstOrDefault();

                if (product.Warehouses != null && product.Warehouses.Any())
                {
                    foreach (var item in product.Warehouses)
                    {
                        item.Active = false;
                        warehouseRepository.Save(item);
                    }
                }

                model.Id = product.Id;
                model.Active = false;

                repository.Save(model);
                result.Success = true;
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to complete delete.";
                result.Error = ex;

                //logService.Insert(ex, "ModelService.Update");
            }

            return result;
        }
    }
}

