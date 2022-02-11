using BelezaNaWeb.Domain.Model;
using BelezaNaWeb.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Service
{

    interface IProductService
    {

    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

    }
}
