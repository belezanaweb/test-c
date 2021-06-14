using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteBoticario.Core.Responses;
using TesteBoticario.Core.Services.Interfaces;
using TesteBoticario.Domain.Entities;
using TesteBoticario.Storage.Interfaces;

namespace TesteBoticario.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductCache _memory;

        public ProductService(IProductCache memory)
        {
            _memory = memory;
        }

        public BaseResponse GetProduct(int sku)
        {
            if (sku == 0)
                return new BaseResponse($"There is no product with Sku {sku} to retrieve", false);

            var product = _memory.Get(sku);

            if (product == null)
                return new BaseResponse($"Product with sku {sku} does not exists.", false);

            return new BaseResponse(product, true);
        }

        public BaseResponse CreateProduct(Product product)
        {
            if (SkuExists(product.Sku))
                return new BaseResponse($"A product with Sku {product.Sku} already exists", false);

            var validations = ValidateProduct(product);
            if (validations.Any())
            {
                return new BaseResponse(validations, false);
            }

            var newProduct = _memory.Insert(product);
            return new BaseResponse(newProduct, true);
        }

        public BaseResponse UpdateProduct(Product product)
        {
            if (!SkuExists(product.Sku))
                return new BaseResponse($"There is no product with Sku {product.Sku} to update", false);

            var validations = ValidateProduct(product);
            if (validations.Any())
            {
                return new BaseResponse(validations, false);
            }

            _memory.Delete(product.Sku);
            var updatedProduct = _memory.Insert(product);

            return new BaseResponse(updatedProduct, true);
        }

        public BaseResponse DeleteProduct(int sku)
        {
            if (sku == 0)
                return new BaseResponse($"There is no product with Sku {sku} to delete", false);

            if (!SkuExists(sku))
                return new BaseResponse($"Product with sku {sku} does not exists.", false);

            var product = _memory.Delete(sku);

            return new BaseResponse(product, true);

        }

        #region Aux

        public List<string> ValidateProduct(Product product)
        {
            var result = new List<string>();

            if (product.Sku == 0)
                result.Add("The 'Sku' property cannot be null or 0");

            if (string.IsNullOrEmpty(product.Name))
                result.Add("The 'Name' property cannot be null or empty");

            return result;
        }

        public bool SkuExists(int sku)
        {
            return _memory.Get(sku) != null;
        }

        #endregion
    }
}
