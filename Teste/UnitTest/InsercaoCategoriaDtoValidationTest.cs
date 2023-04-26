//using Bogus;
//using GerenciamentoProduto.Domains.Validations;
//using GerenciamentoProduto.Domains;
//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using GerenciamentoProduto.Domains.Dtos;

//namespace Test.UnitTest
//{
//    public class InsercaoCategoriaDtoValidationTest
//    {
//        private Faker _faker;
//        private InsercaoCategoriaDtoValidation _insercaoCategoriaValidation;
//        public InsercaoCategoriaDtoValidationTest()
//        {
//            _faker = new Faker("pt_BR");
//            _insercaoCategoriaValidation = new InsercaoCategoriaDtoValidation();
//        }

//        [Fact]
//        public void NaoDeveCriarProdutoQuandoNomeNulo()
//        {
//            var categoria = new InsercaoCategoriaDto(null, _faker.Random.Bool());

//            var excecaoEncontrada = _insercaoCategoriaValidation.TestValidate(categoria);

//            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Nome).WithErrorMessage("O campo Nome não deve ser nulo(a)");
//        }

//        [Fact]
//        public void NaoDeveCriarProdutoQuandoNomeVazio()
//        {
//            var categoria = new Categoria("", _faker.Random.Bool());

//            var excecaoEncontrada = _insercaoCategoriaValidation.TestValidate(categoria);

//            excecaoEncontrada.ShouldHaveValidationErrorFor(categoria => categoria.Nome).WithErrorMessage("O campo Nome não deve ser vazio(a)");
//        }
//    }
//}