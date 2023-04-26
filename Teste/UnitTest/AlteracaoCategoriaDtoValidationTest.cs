using Bogus;
using FluentValidation.TestHelper;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;

namespace Test.UnitTest
{
    public class AlteracaoCategoriaDtoValidationTest
    {
        private Faker _faker;
        private AlteracaoCategoriaDtoValidation _alteracaoCategoriaValidation;
        public AlteracaoCategoriaDtoValidationTest()
        {
            _faker = new Faker("pt_BR");
            _alteracaoCategoriaValidation = new AlteracaoCategoriaDtoValidation();
        }


        [Fact]
        public void NaoDeveAlterarCategoriaSemId()
        {
            var categoria = new AlteracaoCategoriaDto(Guid.Empty, _faker.Commerce.Department(), _faker.Random.Bool());

            var excecaoEncontrada = _alteracaoCategoriaValidation.TestValidate(categoria);

            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Id).WithErrorMessage("O campo Id não deve ser vazio(a)");
        }
    }
}