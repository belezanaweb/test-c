using GrupoBoticario.Domain.Validations.Contracts;
using GrupoBoticario.Domain.Validations.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GrupoBoticario.Domain.Payload.Product
{
    public class ProductUpdatePayload : ProductPayload
    {
        public long Sku { get; set; }

        public override void Validar()
        {
            RemoverNotificacoes();

            InserirNotificacoes(new Contrato()
                .Requer()
                .VerificaSeFalso(Sku <= 0, nameof(Sku), $"O {nameof(Sku)} deve ser maior que zero.")
                .VerificaeSeNaoNuloOuEspacoEmBranco(Name, nameof(Name), $"A propriedade {nameof(Name)} não pode ser nulo ou vazio."));
        }
    }
}
