using FluentValidation;
using GerenciamentoProduto.Domains.Dtos;

namespace GerenciamentoProduto.Domains.Validations
{
    public class AlteracaoCategoriaDtoValidation : CategoriaDtoValidation<AlteracaoCategoriaDto>
    {
        public AlteracaoCategoriaDtoValidation()
        {
            RuleFor(x => x.Id)
            .NotNull().WithMessage(MensagensErro.OCampoNaoDeveSerNulo)
            .NotEmpty().WithMessage(MensagensErro.OCampoNaoDeveSerVazio);

        }
    }
}
