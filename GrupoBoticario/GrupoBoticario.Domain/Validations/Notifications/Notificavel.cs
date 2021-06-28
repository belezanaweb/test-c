using GrupoBoticario.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoBoticario.Domain.Validations.Notifications
{
    public abstract class Notificavel : INotificavel
    {
        private readonly List<Notificacao> _notificacoes;

        protected Notificavel() => _notificacoes = new List<Notificacao>();

        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;

        public IReadOnlyCollection<string> MensagensNotificacoes => _notificacoes.Select(p => p.Mensagem).ToList();

        public string MensagensNotificacoesAgrupadas => MensagensNotificacoes.Agrupar();

        public void InserirNotificacao(string propriedade, string mensagem) => _notificacoes.Add(new Notificacao(propriedade, mensagem));

        public void InserirNotificacao(Notificacao notificacao) => _notificacoes.Add(notificacao);

        public void InserirNotificacoes(IReadOnlyCollection<Notificacao> notificacoes) => _notificacoes.AddRange(notificacoes);

        public void InserirNotificacoes(IList<Notificacao> notificacoes) => _notificacoes.AddRange(notificacoes);

        public void InserirNotificacoes(ICollection<Notificacao> notificacoes) => _notificacoes.AddRange(notificacoes);

        public void InserirNotificacoes(Notificavel item) => InserirNotificacoes(item.Notificacoes);

        public void InserirNotificacoes(params Notificavel[] items)
        {
            foreach (var item in items)
                InserirNotificacoes(item);
        }

        public void RemoverNotificacoes() => _notificacoes.Clear();

        public abstract void Validar();


        public virtual bool Invalido
        {
            get
            {
                RemoverNotificacoes();
                Validar();
                return _notificacoes.Any();
            }
        }
        public virtual void AssineSeguro() 
        {
            if (Invalido is true) 
            {
                var inconsistencias = string.Join(Environment.NewLine, _notificacoes.Select(x => x.Mensagem));
                throw new ArgumentException(inconsistencias);
            }           
        }

        public bool Valido => !Invalido;        
    }
}
