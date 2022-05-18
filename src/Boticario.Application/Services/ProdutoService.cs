using Boticario.Application.Interfaces;
using Boticario.Core.Interfaces.Queries;
using Boticario.Core.Model.Commands.Base;
using Boticario.Core.Model.Commands.Produto;
using Boticario.Core.Model.DTOs.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMediator _mediator;
        private readonly IProdutoQuery _produtoQuery;

        public ProdutoService(IMediator mediator, IProdutoQuery produtoQuery)
        {
            _mediator = mediator;
            _produtoQuery = produtoQuery;
        }

        public async Task<CommandResult> Atualizar(AtualizarProdutoCommand produto)
        {
            return await _mediator.Send(produto);
        }

        public async Task<CommandResult> Excluir(long sku)
        {
            return await _mediator.Send(new ExcluirProdutoCommand
            {
                Sku = sku
            });
        }

        public async Task<CommandResult> Inserir(InserirProdutoCommand produto)
        {
            return await _mediator.Send(produto);
        }

        public async Task<List<ProdutoDTO>> Listar()
        {
            return await _produtoQuery.Listar();
        }

        public async Task<ProdutoDTO> ObterPorSKU(long sku)
        {
            return await _produtoQuery.ObterPorSKU(sku);
        }
    }
}