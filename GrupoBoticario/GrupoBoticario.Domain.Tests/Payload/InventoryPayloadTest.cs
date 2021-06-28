using GrupoBoticario.Domain.Payload.Product;
using System.Collections.Generic;
using Xunit;

namespace GrupoBoticario.Domain.Tests.Payload
{
    public class InventoryPayloadTest
    {
        [Fact]
        public void Testa_InventoryPayload_Valido()
        {

            var payload = new InventoryPayload
            {
                WareHouses = new List<WareHousePayload>
                { 
                    new WareHousePayload
                    {
                        Locality = "SP",
                        Quantity = 12,
                        Type = "PHYSICAL_STORE"
                    }
                }
            };

            Assert.True(payload.Valido);
        }

        [Fact]
        public void Testa_InventoryPayload_WareHouse_Nulo()
        {

            var payload = new InventoryPayload
            {
                WareHouses = null
            };

            Assert.False(payload.Valido);
        }

        [Fact]
        public void Testa_InventoryPayload_WareHouse_Vazio()
        {

            var payload = new InventoryPayload
            {
                WareHouses = new List<WareHousePayload>()
            };

            Assert.False(payload.Valido);
        }
    }
}
