using Projeto.Domain.Interfaces;
using System;

namespace Projeto.Domain.Services
{
    public class TelemetryService : ITelemetryService
    {
        public void TrackException(Exception exception, string message)
        {
            // TODO: implementar o registro do erros para monitoramento/log de falha do sistema
            // para simplificar o projeto eu não implementei tal solução.
        }
    }
}
