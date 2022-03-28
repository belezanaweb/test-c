using BackendTest.Domain.Entities;
using System;

namespace BackendTest.Domain.Commands.Responses
{
    public class GetProductBySkuResponse
    {
        private static readonly string NotExists = "This product does not exist!";
        private static readonly string SuccessMensage = "Product found!";
        public string Mensage { get; set; }
        public Product Product { get; set; }

        private GetProductBySkuResponse(string mensage)
        {
            Mensage = mensage;
        }

        private GetProductBySkuResponse(Product product)
        {
            Product = product;
            Mensage = SuccessMensage;
        }

        public static GetProductBySkuResponse Success(Product product)
        {
            return new GetProductBySkuResponse(product);
        }

        public static GetProductBySkuResponse Error(string mensage)
        {
            return new GetProductBySkuResponse(mensage);
        }

        public static GetProductBySkuResponse NExists()
        {
            return new GetProductBySkuResponse(NotExists);
        }
    }
}
