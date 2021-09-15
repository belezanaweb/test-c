using Bogus;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System.Collections.Generic;
using Xunit;

namespace Projeto.Domain.UnitTest.Validations
{
    public class ProdutoValidationTest
    {
        private readonly ProdutoValidation _validator;

        public ProdutoValidationTest()
        {
            _validator = new ProdutoValidation();
        }

        [Theory(DisplayName = "Deve validar o produto com sucesso")]
        [MemberData(nameof(CreateProduto))]
        public void ValidarProdutoComSucesso(Produto produto)
        {
            var result = _validator.Validate(produto);

            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Deve validar o produto com erro")]
        public void ValidarProdutoComErro()
        {
            var produto = new Produto() { Sku = 0, Nome = string.Empty };
            var result = _validator.Validate(produto);

            Assert.False(result.IsValid);
            Assert.Equal(2, result.Errors.Count);
        }

        public static IEnumerable<object[]> CreateProduto()
        {
            var faker = new Faker<Produto>("pt_BR")
                .RuleFor(c => c.Sku, c => c.Random.Int(1))
                .RuleFor(c => c.Nome, c => c.Random.String2(255));

            foreach (var item in faker.Generate(5))
            {
                yield return new[] { item };
            }
        }
    }
}
