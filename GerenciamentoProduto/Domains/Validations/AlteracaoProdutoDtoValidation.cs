using FluentValidation;
using GerenciamentoProduto.Domains.Dtos;

namespace GerenciamentoProduto.Domains.Validations
{
    public class AlteracaoProdutoDtoValidation : ProdutoDtoValidation<AlteracaoProdutoDto>
    {
        public AlteracaoProdutoDtoValidation()
        {
            RuleFor(x => x.Id)
             .NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo)
             .NotEmpty().WithMessage(MensagensErro.OCampoNaoDeveSerVazio);

            RuleFor(x => x.CategoriaId)
             .NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo)
             .NotEmpty().WithMessage(MensagensErro.OCampoNaoDeveSerVazio);
        }
    }
}
