using AutoBogus;
using Bogus;
using FluentValidation.TestHelper;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;

namespace Test.UnitTest
{
    public class AlteracaoProdutoDtoValidationTest
    {
        private Faker _faker;
        private AlteracaoProdutoDtoValidation _alteracaoProdutoValidation;

        public AlteracaoProdutoDtoValidationTest()
        {
            _faker = new Faker("pt_BR");
            _alteracaoProdutoValidation = new AlteracaoProdutoDtoValidation();
        }


        [Fact]
        public void NaoDeveAlterarProdutoSemId()
        {
            var categoria = new AlteracaoProdutoDto(Guid.Empty,_faker.Commerce.ProductName(), _faker.Commerce.Department(),_faker.Random.Decimal(1), _faker.Random.Bool());

            var excecaoEncontrada = _alteracaoProdutoValidation.TestValidate(categoria);

            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Id).WithErrorMessage("O campo Id não deve ser vazio(a)");
        }

        [Fact]
        public void NaoDeveAlterarProdutoSemCategoriaId()
        {
            var produto = new AutoFaker<AlteracaoProdutoDto>().Generate();
            produto.CategoriaId = Guid.Empty;
            var excecaoEncontrada = _alteracaoProdutoValidation.TestValidate(produto);

            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.CategoriaId).WithErrorMessage("O campo Categoria Id não deve ser vazio(a)");
        }
    }
}