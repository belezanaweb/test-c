using GrupoBoticario.Domain.Payload.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GrupoBoticario.Domain.Tests.Payload
{
    public class WareHousePayloadTest
    {
        [Fact]
        public void Testa_WareHousePayload_Valido()
        {

            var payload = new WareHousePayload
            {
                Locality = "SP",
                Quantity = 12,
                Type = "PHYSICAL_STORE"

            };

            Assert.True(payload.Valido);
        }

        [Fact]
        public void Testa_WareHousePayload_Propridedade_Locality_Nulo()
        {

            var payload = new WareHousePayload
            {
                Locality = null,
                Quantity = 12,
                Type = "PHYSICAL_STORE"

            };

            Assert.False(payload.Valido);
        }
        [Fact]
        public void Testa_WareHousePayload_Propridedade_Locality_Vazia()
        {

            var payload = new WareHousePayload
            {
                Locality = string.Empty,
                Quantity = 12,
                Type = "PHYSICAL_STORE"

            };

            Assert.False(payload.Valido);
        }

        [Fact]
        public void Testa_WareHousePayload_Propridedade_Quantity_Zero()
        {

            var payload = new WareHousePayload
            {
                Locality = "Go",
                Quantity = 0,
                Type = "PHYSICAL_STORE"

            };

            Assert.False(payload.Valido);
        }

        [Fact]
        public void Testa_WareHousePayload_Propridedade_Quantity_Negativo()
        {

            var payload = new WareHousePayload
            {
                Locality = "Go",
                Quantity = -10,
                Type = "PHYSICAL_STORE"

            };

            Assert.False(payload.Valido);
        }

        [Fact]
        public void Testa_WareHousePayload_Propridedade_Type_Invalido()
        {

            var payload = new WareHousePayload
            {
                Locality = "Go",
                Quantity = 10,
                Type = "PHYSICAL"

            };

            Assert.False(payload.Valido);
        }
    }
}
