using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces.Repository;
using BelezaNaWeb.Infra.Data.Context;
using Emprestae.Infra.Data.Repositories;

namespace BelezaNaWeb.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
