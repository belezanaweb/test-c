using Bogus;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System.Collections.Generic;
using Xunit;

namespace Projeto.Domain.UnitTest.Validations
{
    public class WarehouseValidationTest
    {
        private readonly WarehouseValidation _validator;

        public WarehouseValidationTest()
        {
            _validator = new WarehouseValidation();
        }

        [Theory(DisplayName = "Deve validar o warehouse com sucesso")]
        [MemberData(nameof(CreateWarehouse))]
        public void ValidarProdutoComSucesso(Warehouse warehouse)
        {
            var result = _validator.Validate(warehouse);

            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Deve validar o warehouse com erro")]
        public void ValidarProdutoComErro()
        {
            var produto = new Warehouse()
            { 
                ProdutoSku = 0, 
                Locality = string.Empty, 
                Quantity = -1, 
                Type = string.Empty
            };
            var result = _validator.Validate(produto);

            Assert.False(result.IsValid);
            Assert.Equal(4, result.Errors.Count);
        }

        public static IEnumerable<object[]> CreateWarehouse()
        {
            var faker = new Faker<Warehouse>("pt_BR")
                .RuleFor(c => c.ProdutoSku, c => c.Random.Int(1))
                .RuleFor(c => c.Locality, c => c.Address.City())
                .RuleFor(c => c.Quantity, c => c.Random.Int(1))
                .RuleFor(c => c.Type, c => c.Random.String2(15));

            foreach (var item in faker.Generate(5))
            {
                yield return new[] { item };
            }
        }
    }
}
