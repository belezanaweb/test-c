using Boticario.Core.Domains;
using Boticario.Core.Helpers;
using Boticario.Core.Interfaces.Repositories;
using Boticario.Core.Interfaces.UoW;
using Boticario.Core.Model.Commands.Base;
using Boticario.Core.Model.Commands.Produto;
using Boticario.Core.ValidationQueries;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boticario.Core.Handlers.Produto
{
    public class ExcluirProdutoHandler : CommandHandler<ExcluirProdutoCommand, CommandResult>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ExcluirProdutoHandler(IUnitOfWork unitOfWork, IProdutoRepository produtoRepository)
            : base(unitOfWork)
        {
            _produtoRepository = produtoRepository;
        }

        public override async Task<CommandResult> Handle(ExcluirProdutoCommand produtoCommand, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.Obter(ProdutoValidationQuery.GetBySku(produtoCommand.Sku));

            if (produto == null)
                return new CommandResult(false, erro: "O produto não foi encontrado.");

            await _produtoRepository.Deletar(produto.Id);

            await Commit();

            return new CommandResult(true);
        }
    }
}