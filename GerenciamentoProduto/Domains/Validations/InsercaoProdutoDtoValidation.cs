using FluentValidation;
using GerenciamentoProduto.Domains.Dtos;

namespace GerenciamentoProduto.Domains.Validations
{
    public class InsercaoProdutoDtoValidation : ProdutoDtoValidation<InsercaoProdutoDto>
    {
        public InsercaoProdutoDtoValidation()
        {
            RuleFor(x => x.CategoriaId)
                .NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo)
                .NotEmpty().WithMessage(MensagensErro.OCampoNaoDeveSerVazio);
        }
    }
}
