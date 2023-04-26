using FluentValidation;
using GerenciamentoProduto.Domains.Dtos;

namespace GerenciamentoProduto.Domains.Validations
{
    public class CategoriaDtoValidation<T> : AbstractValidator<T> where T: CategoriaDto
    {
        public CategoriaDtoValidation()
        {
            RuleFor(p => p.Nome).NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo);
            RuleFor(p => p.Nome).NotEmpty().WithMessage(MensagensErro.OCampoNaoDeveSerVazio);

            RuleFor(p => p.Situacao).NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo);

        }
    }
}
