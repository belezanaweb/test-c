using GrupoBoticario.Domain.Enums;
using GrupoBoticario.Domain.Validations.Contracts;
using GrupoBoticario.Domain.Validations.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Domain.Payload.Product
{
    public class WareHousePayload : Notificavel
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public override void Validar()
        {
            RemoverNotificacoes();

            InserirNotificacoes(new Contrato()
                .Requer()
                .VerificaeSeNaoNuloOuVazio(Locality, nameof(Locality), $"A propriedade {nameof(Locality)} não pode ser nula.")
                .VerificaeSeNaoNuloOuVazio(Type, nameof(Type), $"A propriedade {nameof(Type)} não pode ser nula ou vazia.")
                .VerificaSeFalso(VerificaTipoWareHouseInvalido(), nameof(Type), $"O type da  propriedade {nameof(Type)} inválido.")
                .VerificaSeFalso(Quantity <= 0, nameof(Quantity), $"A propriedade {nameof(Quantity)} deve ser maior que zero."));
        }

        private bool VerificaTipoWareHouseInvalido()
        {
            return Enum.TryParse(typeof(EnumTypeWareHouse), Type, out _) is false;
        }
    }
}
