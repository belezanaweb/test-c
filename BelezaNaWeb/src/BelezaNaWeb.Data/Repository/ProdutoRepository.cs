using BelezaNaWeb.Data.Context;
using BelezaNaWeb.Domain.Models.Repository;
using BelezaNaWeb.Domain.Produtos;

namespace BelezaNaWeb.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(BelezaNaWebContext context) : base(context)
        {
        }
    }
}
