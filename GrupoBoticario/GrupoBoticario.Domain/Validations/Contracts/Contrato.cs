using GrupoBoticario.Domain.Validations.Notifications;
using System;
using System.Linq;

namespace GrupoBoticario.Domain.Validations.Contracts
{
    public partial class Contrato : Notificavel
    {
        public Contrato Requer() 
        {
            return this;
        }

        public override void Validar()
        {
            throw new NotImplementedException("Deve ser implementado.");
        }

        public override bool Invalido => Notificacoes.Any();
    }
}
