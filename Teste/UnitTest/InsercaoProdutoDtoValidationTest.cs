using Bogus;

using FluentValidation.TestHelper;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;

namespace Test.UnitTest
{
    public class InsercaoProdutoDtoValidationTest
    {

        private Faker _faker;
        private InsercaoProdutoDtoValidation _insercaoProdutoValidation;
        public InsercaoProdutoDtoValidationTest()
        {
            _faker = new Faker("pt_BR");
            _insercaoProdutoValidation = new InsercaoProdutoDtoValidation();
        }
    }
}