using Boticario.Core.Model.Commands.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Model.Commands.Produto
{
    public class ExcluirProdutoCommand : IRequest<CommandResult>
    {
        public long Sku { get; set; }
    }
}
