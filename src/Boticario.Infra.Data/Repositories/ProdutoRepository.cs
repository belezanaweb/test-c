using AutoMapper;
using Boticario.Core.Domains;
using Boticario.Core.Interfaces.Repositories;
using Boticario.Data.Context;
using Boticario.Data.Repositories.Base;
using Boticario.Infra.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto, TabelaProduto>, IProdutoRepository
    {
        public ProdutoRepository(DefaultContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override async Task<TabelaProduto> ConverteDominioParaEntidade(Produto dominio, TabelaProduto entidade)
        {
            entidade.Id = dominio.Id;
            entidade.Sku = dominio.Sku;
            entidade.Nome = dominio.Nome;

            entidade.TabelaEstoque.Clear();

            entidade.TabelaEstoque = dominio.Estoque.Select(x => new TabelaEstoque
            {
                Id = x.Id,
                Local = x.Local,
                Quantidade = x.Quantidade,
                Tipo = x.Tipo
            }).ToList();

            return entidade;
        }
    }
}
