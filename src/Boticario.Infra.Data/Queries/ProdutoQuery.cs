using AutoMapper;
using Boticario.Core.Interfaces.Queries;
using Boticario.Core.Model.DTOs.Produto;
using Boticario.Data.Context;
using Boticario.Data.Queries.Base;
using Boticario.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Infra.Data.Queries
{
    public class ProdutoQuery : BaseQuery<ProdutoDTO, TabelaProduto>, IProdutoQuery
    {
        public ProdutoQuery(DefaultContext context, IMapper imapper) : base(context, imapper)
        {
        }

        public async Task<ProdutoDTO> ObterPorSKU(long sku)
        {
            return await Get(x => x.Sku == sku);
        }

        public async Task<List<ProdutoDTO>> Listar()
        {
            return await GetList();
        }
    }
}
