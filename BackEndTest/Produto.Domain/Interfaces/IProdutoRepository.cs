using Produto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Produto.Domain.Repositories
{
    public interface IProdutoRepository
    {
        void AddAsync(Models.Product product);

        Product FindBy(string sku);

        void Update(Models.Product product);

        Boolean Remove(Models.Product product);
    }
}
