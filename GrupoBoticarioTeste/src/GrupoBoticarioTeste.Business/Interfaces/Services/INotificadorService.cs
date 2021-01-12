using GrupoBoticarioTeste.Business.Notificacoes;
using System.Collections.Generic;

namespace GrupoBoticarioTeste.Business.Interfaces.Services
{
    public interface INotificadorService
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
