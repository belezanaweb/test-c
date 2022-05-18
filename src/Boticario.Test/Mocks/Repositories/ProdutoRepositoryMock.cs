using Boticario.Core.Domains;
using Boticario.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Tests.Mocks.Repositories
{
    public class ProdutoRepositoryMock : RepositoryBaseMock<Produto>, IProdutoRepository
    {
        public override IEnumerable<Produto> PopulateEntities()
        {
            yield return new Produto
            {
                Id = 1,
                Sku = 23213,
                Nome = "Creme Capilar",
                Estoque = new List<Estoque>
                {
                    new Estoque
                    {
                        Id = 1,
                        Local = "SP",
                        Quantidade = 2,
                        Tipo = "ECOMMERCE"
                    }
                }
            };

            yield return new Produto
            {
                Id = 2,
                Sku = 6543,
                Nome = "Rimel",
                Estoque = new List<Estoque>()
            };

            yield return new Produto
            {
                Id = 3,
                Sku = 78899,
                Nome = "Perfume Exótico",
                Estoque = new List<Estoque>
                {
                    new Estoque
                    {
                        Id = 2,
                        Local = "RS",
                        Quantidade = 67,
                        Tipo = "ECOMMERCE"
                    },
                    new Estoque
                    {
                        Id = 3,
                        Local = "RJ",
                        Quantidade = 54,
                        Tipo = "PHYSICAL_STORE"
                    }
                }
            };
        }
    }
}
