using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Model.Commands.Base
{
    public class CommandResult
    {
        public CommandResult(bool sucesso)
        {
            Sucesso = sucesso;
        }

        public CommandResult(bool sucesso, string? erro = null)
        {
            Sucesso = sucesso;

            Erros = new List<CommandResultErro>
            {
                new CommandResultErro("Geral", erro)
            };
        }

        public CommandResult(bool sucesso, IList<CommandResultErro>? erros = null)
        {
            Sucesso = sucesso;
            Erros = erros;
        }

        public bool Sucesso { get; set; }

        public IList<CommandResultErro>? Erros { get; private set; }
    }

    public class CommandResultErro
    {
        public CommandResultErro(string propriedade, string? mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; set; }

        public string? Mensagem { get; set; }
    }
}
