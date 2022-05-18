using Boticario.Core.Model.Commands.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Model.Commands.Produto
{
    public class InserirProdutoCommand : IRequest<CommandResult>
    {
        public string Name { get; set; }

        public long Sku { get; set; }

        public InserirProdutoInventarioCommand Inventory { get; set; }
    }

    public class InserirProdutoInventarioCommand
    {
        public List<InserirProdutoEstoqueCommand> Warehouses { get; set; } = new List<InserirProdutoEstoqueCommand>();
    }

    public class InserirProdutoEstoqueCommand
    {
        public string Locality { get; set; }

        public int? Quantity { get; set; }

        public string Type { get; set; }
    }
}
