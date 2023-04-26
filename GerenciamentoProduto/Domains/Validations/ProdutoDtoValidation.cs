using FluentValidation;
using GerenciamentoProduto.Domains.Dtos;

namespace GerenciamentoProduto.Domains.Validations
{
    public class ProdutoDtoValidation<T>:  AbstractValidator<T> where T : ProdutoDto
    {
        public ProdutoDtoValidation()
        {
            RuleFor(p => p.Nome).NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo);
            RuleFor(p => p.Nome).NotEmpty().WithMessage(MensagensErro.OCampoNaoDeveSerVazio);

            RuleFor(p => p.Descricao).NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo);
            RuleFor(p => p.Descricao).NotEmpty().WithMessage(MensagensErro.OCampoNaoDeveSerVazio);

            RuleFor(p => p.Situacao).NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo);

            RuleFor(p => p.Preco).GreaterThan(0).WithMessage(MensagensErro.OCampoDeveSerMaiorQue);
        }
    }
}
