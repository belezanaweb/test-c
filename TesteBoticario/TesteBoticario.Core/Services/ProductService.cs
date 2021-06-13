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

        public BaseResponse CreateProduct(Product product)
        {
            var validations = ValidateProduct(product);
            if (validations.Any())
            {
                return new BaseResponse(validations, false);
            }

            var newProduct = _memory.Insert(product);
            return new BaseResponse(newProduct, true);
        }

        public List<string> ValidateProduct(Product product)
        {
            var result = new List<string>();

            if (product.Sku == 0)
                result.Add("The 'Sku' property cannot be null or 0");

            if (string.IsNullOrEmpty(product.Name))
                result.Add("The 'Name' property cannot be null or empty");

            return result;
        }
    }
}
