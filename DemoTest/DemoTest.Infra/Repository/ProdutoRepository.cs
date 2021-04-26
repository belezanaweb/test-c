using DemoTest.Domain.Entities;
using DemoTest.Domain.Repository.Interfaces;

namespace DemoTest.Infra.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ContextRepository context) : base(context) { }
    }
}
