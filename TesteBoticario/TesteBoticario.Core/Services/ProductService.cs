using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteBoticario.Core.Responses;
using TesteBoticario.Core.Services.Interfaces;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Services
{
    public class ProductService : IProductService
    {
        public BaseResponse CreateProduct(Product product)
        {
            var validations = ValidateProduct(product);
            if (validations.Any())
            {
                return new BaseResponse(validations, false);
            }

            //memory.add
            return new BaseResponse(product, true);
        }

        public List<string> ValidateProduct(Product product)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(product.Name))
                result.Add("The 'Name' property cannot be null or empty");

            return result;
        }
    }
}
