using Bogus;
using FluentValidation.TestHelper;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;

namespace Test.UnitTest
{
    public class CategoriaDtoTest
    {
        private Faker _faker;
        private CategoriaDtoValidation<CategoriaDto> _categoriaDtoValidation;
        public CategoriaDtoTest()
        {
            _faker = new Faker("pt_BR");
            _categoriaDtoValidation = new CategoriaDtoValidation<CategoriaDto>();
        }

        [Fact]
        public void NaoDeveCriarProdutoQuandoNomeNulo()
        {
            var categoria = new CategoriaDto(null, _faker.Random.Bool());

            var excecaoEncontrada = _categoriaDtoValidation.TestValidate(categoria);

            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Nome).WithErrorMessage("O campo Nome não deve ser nulo(a)");
        }

        [Fact]
        public void NaoDeveCriarProdutoQuandoNomeVazio()
        {
            var categoria = new CategoriaDto("", _faker.Random.Bool());

            var excecaoEncontrada = _categoriaDtoValidation.TestValidate(categoria);

            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Nome).WithErrorMessage("O campo Nome não deve ser vazio(a)");
        }
    }
}
