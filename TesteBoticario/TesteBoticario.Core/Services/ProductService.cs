using System.Collections.Generic;
using System.Linq;
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
            var product = _memory.Get(sku);

            if (product == null)
                return new BaseResponse($"There is no product with Sku {sku} to retrieve.", 404, false);

            return new BaseResponse(product, 200, true);
        }

        public BaseResponse CreateProduct(Product product)
        {
            if (SkuExists(product.Sku))
                return new BaseResponse($"A product with Sku {product.Sku} already exists.", 409, false);

            var validations = ValidateProduct(product);
            if (validations.Any())
            {
                return new BaseResponse(validations, 400, false);
            }

            var newProduct = _memory.Insert(product);
            return new BaseResponse(newProduct, 200, true);
        }

        public BaseResponse UpdateProduct(Product product)
        {
            if (!SkuExists(product.Sku))
                return new BaseResponse($"There is no product with Sku {product.Sku} to update.", 404, false);

            var validations = ValidateProduct(product);
            if (validations.Any())
            {
                return new BaseResponse(validations, 400, false);
            }

            _memory.Delete(product.Sku);
            var updatedProduct = _memory.Insert(product);

            return new BaseResponse(updatedProduct, 200, true);
        }

        public BaseResponse DeleteProduct(int sku)
        {
            if (!SkuExists(sku))
                return new BaseResponse($"There is no product with Sku {sku} to delete.", 404, false);

            var product = _memory.Delete(sku);

            return new BaseResponse(product, 200, true);

        }

        #region Aux

        public List<string> ValidateProduct(Product product)
        {
            var result = new List<string>();

            if (product.Sku == 0)
                result.Add("The 'Sku' property cannot be null or 0.");

            if (string.IsNullOrEmpty(product.Name))
                result.Add("The 'Name' property cannot be null or empty.");

            foreach (var warehouse in product.Warehouses)
            {
                if (string.IsNullOrEmpty(warehouse.Locality))
                    result.Add("The 'Locality' property in the warehouse cannot be null or empty.");

                if (warehouse.Quantity == 0)
                    result.Add("The 'Quantity' property in the warehouse cannot be null or 0.");

                if (string.IsNullOrEmpty(warehouse.Type))
                    result.Add("The 'Type' property in the warehouse cannot be null or empty.");
            }

            return result;
        }

        public bool SkuExists(int sku)
        {
            return _memory.Get(sku) != null;
        }

        public bool ProductIsMarketable(List<Warehouse> warehouses)
        {
            return CalculateInventoryQuantity(warehouses) > 0;
        }

        public int CalculateInventoryQuantity(List<Warehouse> warehouses)
        {
            return warehouses.Sum(w => w.Quantity);
        }

        #endregion
    }
}
