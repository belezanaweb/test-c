using GrupoBoticario.Domain.Validations.Contracts;
using GrupoBoticario.Domain.Validations.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoBoticario.Domain.Payload.Product
{
    public class InventoryPayload : Notificavel
    {
        public IEnumerable<WareHousePayload> WareHouses { get; set; }

        public override void Validar()
        {
            RemoverNotificacoes();

            InserirNotificacoes(new Contrato()
                .Requer()
                .VerificaSeFalso(WareHouses is null is true, nameof(WareHouses), $"A {nameof(WareHouses)} não pode ser nula.")
                .VerificaSeFalso(WareHouses is null is false && WareHouses.Any() is false, nameof(WareHouses), $"A {nameof(WareHouses)} não pode ser vazia."));
        }
    }
}
