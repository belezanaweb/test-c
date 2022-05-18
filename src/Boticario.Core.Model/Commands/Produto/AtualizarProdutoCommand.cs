using Boticario.Core.Model.Commands.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Model.Commands.Produto
{
    public class AtualizarProdutoCommand : IRequest<CommandResult>
    {
        public string Name { get; set; }

        public long Sku { get; set; }

        public AtualizarProdutoInventarioCommand Inventory { get; set; }
    }

    public class AtualizarProdutoInventarioCommand
    {
        public List<AtualizarProdutoEstoqueCommand> Warehouses { get; set; } = new List<AtualizarProdutoEstoqueCommand>();
    }

    public class AtualizarProdutoEstoqueCommand
    {
        public string Locality { get; set; }

        public int? Quantity { get; set; }

        public string Type { get; set; }
    }
}
