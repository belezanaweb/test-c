using GrupoBoticario.Domain.Validations.Contracts;
using GrupoBoticario.Domain.Validations.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GrupoBoticario.Domain.Payload.Product
{
    public class ProductPayload : Notificavel
    {
        public string Name { get; set; }

        public InventoryPayload Inventory { get; set; }        

        public override void Validar()
        {
            RemoverNotificacoes();

            InserirNotificacoes(new Contrato()
                .Requer()                
                .VerificaeSeNaoNuloOuEspacoEmBranco(Name, nameof(Name), $"A propriedade {nameof(Name)} não pode ser nulo ou vazio."));
        }
    }
}
