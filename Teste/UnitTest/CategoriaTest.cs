//using Bogus;
//using FluentValidation.TestHelper;
//using GerenciamentoProduto.Domains;
//using GerenciamentoProduto.Domains.Validations;

//namespace Test.UnitTest.CategoriaTest
//{
//    public class CategoriaTest
//    {
//        private Faker _faker;
//        private CategoriaDtoValidation _produtoValidation;
//        public CategoriaTest()
//        {
//            _faker = new Faker("pt_BR");
//            _produtoValidation = new CategoriaDtoValidation();
//        }

//        [Fact]
//        public void NaoDeveCriarProdutoQuandoNomeNulo()
//        {
//            var categoria = new Categoria(null, _faker.Random.Bool());

//            var excecaoEncontrada = _produtoValidation.TestValidate(categoria);

//            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Nome).WithErrorMessage("O campo Nome não deve ser nulo(a)");
//        }

//        [Fact]
//        public void NaoDeveCriarProdutoQuandoNomeVazio()
//        {
//            var categoria = new Categoria("", _faker.Random.Bool());

//            var excecaoEncontrada = _produtoValidation.TestValidate(categoria);

//            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Nome).WithErrorMessage("O campo Nome não deve ser vazio(a)");
//        }
//    }
//}
