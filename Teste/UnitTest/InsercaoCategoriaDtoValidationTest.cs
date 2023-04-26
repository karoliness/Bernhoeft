using Bogus;
using FluentValidation.TestHelper;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;

namespace Test.UnitTest
{
    public class InsercaoCategoriaDtoValidationTest
    {
        private Faker _faker;
        private InsercaoCategoriaDtoValidation _insercaoCategoriaValidation;
        public InsercaoCategoriaDtoValidationTest()
        {
            _faker = new Faker("pt_BR");
            _insercaoCategoriaValidation = new InsercaoCategoriaDtoValidation();
        }

    }
}