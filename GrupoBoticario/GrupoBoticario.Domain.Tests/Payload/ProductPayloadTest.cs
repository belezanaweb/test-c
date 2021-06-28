using GrupoBoticario.Domain.Payload.Product;
using Xunit;

namespace GrupoBoticario.Domain.Tests.Payload
{
    public class ProductPayloadTest
    {

        [Fact]
        public void Testa_ProductPayload_Name_Vazio()
        {

            var payload = new ProductSavePayload { Name = string.Empty };

            Assert.False(payload.Valido);
        }

        [Fact]
        public void Testa_ProductPayload_Sku_Valor_Zero_Para_Atualizacao()
        {

            var payload = new ProductUpdatePayload { Name = "Teste atualizacao", Sku = 0 };

            Assert.False(payload.Valido);
        }

        [Fact]
        public void Testa_ProductPayload_Valido_Atualizacao()
        {

            var payload = new ProductUpdatePayload { Name = "Teste atualizacao", Sku = 10 };

            Assert.True(payload.Valido);
        }
        [Fact]
        public void Testa_ProductPayload_Valido_Cadastro()
        {

            var payload = new ProductSavePayload { Name = "Teste Cadastro" };

            Assert.True(payload.Valido);
        }
    }
}
