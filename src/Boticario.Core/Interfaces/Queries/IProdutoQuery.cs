using Boticario.Core.Model.DTOs.Produto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Core.Interfaces.Queries
{
    public interface IProdutoQuery
    {
        Task<ProdutoDTO> ObterPorSKU(long sku);
        Task<List<ProdutoDTO>> Listar();
    }
}
