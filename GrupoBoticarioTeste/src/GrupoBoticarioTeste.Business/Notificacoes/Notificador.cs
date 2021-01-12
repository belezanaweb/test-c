using GrupoBoticarioTeste.Business.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace GrupoBoticarioTeste.Business.Notificacoes
{
    public class Notificador : INotificadorService
    {
        private readonly List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
