using Bogus;
using FluentValidation.TestHelper;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;

namespace Test.UnitTest
{
    public class ProdutoDtoTest
    {
        private Faker _faker;
        private ProdutoDtoValidation<ProdutoDto> _produtoValidation;
        public ProdutoDtoTest()
        {
            _faker = new Faker("pt_BR");
            _produtoValidation = new ProdutoDtoValidation<ProdutoDto>();
        }

        [Fact]
        public void DeveCriarProdutoQuandoTodasAsPropriedadesEstiveremCorreta()
        {
            var produto = new ProdutoDto(_faker.Commerce.ProductName(), _faker.Commerce.ProductDescription(), _faker.Random.Decimal(min: 1), _faker.Random.Bool());

            var excecaoEncontrada = _produtoValidation.TestValidate(produto);

            excecaoEncontrada.ShouldNotHaveValidationErrorFor(produto => produto.Nome);
            excecaoEncontrada.ShouldNotHaveValidationErrorFor(produto => produto.Descricao);
            excecaoEncontrada.ShouldNotHaveValidationErrorFor(produto => produto.Preco);
        }

        [Fact]
        public void NaoDeveCriarProdutoQuandoNomeNulo()
        {
            var produto = new ProdutoDto(null, _faker.Commerce.ProductDescription(), _faker.Random.Decimal(), _faker.Random.Bool());

            var excecaoEncontrada = _produtoValidation.TestValidate(produto);

            excecaoEncontrada.ShouldHaveValidationErrorFor(produto => produto.Nome).WithErrorMessage("O campo Nome não deve ser nulo(a)");
        }

        [Fact]
        public void NaoDeveCriarProdutoQuandoNomeVazio()
        {
            var produto = new ProdutoDto("", _faker.Commerce.ProductDescription(), _faker.Random.Decimal(), _faker.Random.Bool());

            var excecaoEncontrada = _produtoValidation.TestValidate(produto);

            excecaoEncontrada.ShouldHaveValidationErrorFor(produto => produto.Nome).WithErrorMessage("O campo Nome não deve ser vazio(a)");
        }

        [Fact]
        public void NaoDeveCriarProdutoQuandoDescricaoNula()
        {
            var produto = new ProdutoDto(_faker.Commerce.ProductName(), null, _faker.Random.Decimal(), _faker.Random.Bool());

            var excecaoEncontrada = _produtoValidation.TestValidate(produto);

            excecaoEncontrada.ShouldHaveValidationErrorFor(produto => produto.Descricao).WithErrorMessage("O campo Descricao não deve ser nulo(a)");
        }

        [Fact]
        public void NaoDeveCriarProdutoQuandoDescricaoVazia()
        {
            var produto = new ProdutoDto(_faker.Commerce.ProductName(), "", _faker.Random.Decimal(), _faker.Random.Bool());

            var excecaoEncontrada = _produtoValidation.TestValidate(produto);

            excecaoEncontrada.ShouldHaveValidationErrorFor(produto => produto.Descricao).WithErrorMessage("O campo Descricao não deve ser vazio(a)");
        }


        [Fact]
        public void NaoDeveCriarProdutoQuandoPrecoMenorOuIgualQue0()
        {
            var produto = new ProdutoDto(_faker.Commerce.ProductName(), _faker.Commerce.ProductDescription(), _faker.Random.Decimal(max: 0), _faker.Random.Bool());

            var excecaoEncontrada = _produtoValidation.TestValidate(produto);

            excecaoEncontrada.ShouldHaveValidationErrorFor(produto => produto.Preco).WithErrorMessage("O campo Preco deve ser maior que 0");
        }

    }
}