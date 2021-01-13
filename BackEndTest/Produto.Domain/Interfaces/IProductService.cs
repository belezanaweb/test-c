using Produto.Domain.Models;
using System;

namespace Produto.Domain.Services
{
    public interface IProductService
    {
        Models.Product FindBy(string sku);

        Product AddAsync(Models.Product product);

        Product Update(int id, Models.Product product);

        Boolean Remove(String sku);
    }
}
