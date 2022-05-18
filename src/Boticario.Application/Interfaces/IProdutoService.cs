using Boticario.Core.Model.Commands.Base;
using Boticario.Core.Model.Commands.Produto;
using Boticario.Core.Model.DTOs.Produto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> ObterPorSKU(long sku);

        Task<List<ProdutoDTO>> Listar();

        Task<CommandResult> Inserir(InserirProdutoCommand produto);

        Task<CommandResult> Atualizar(AtualizarProdutoCommand produto);

        Task<CommandResult> Excluir(long sku);
    }
}
