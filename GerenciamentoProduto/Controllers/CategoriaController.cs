using FluentValidation;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;
using GerenciamentoProduto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProduto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
        {
            _logger = logger;
            _categoriaService = categoriaService;
        }

        [HttpGet("obter")]
        public async Task<IActionResult> ObterTodasAsCategorias()
        {
            var categorias = await _categoriaService.ObterTodasAsCategorias();

            if (!categorias.Any())
            {
                return StatusCode(404, MensagensErro.NaoEncontrado);

            }
            return StatusCode(202, CategoriaComProdutoDto.ConverterCategoriasComProdutos(categorias));
        }

        [HttpGet("situacao/{situacao}")]
        public async Task<IActionResult> ObterPorSituacao([FromRoute]bool situacao) 
        {
            var categorias = await _categoriaService.ObterCategoriasPorSituacaoAsync(situacao);

            if (!categorias.Any())
            {
                return StatusCode(404, MensagensErro.NaoEncontrado);

            }

            return StatusCode(202, CategoriaComProdutoDto.ConverterCategoriasComProdutos(categorias));
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> ObterPorNome([FromRoute] string nome)
        {
            var categorias = await _categoriaService.ObterCategoriasPorNomeAsync(nome);

            if (!categorias.Any())
            {
                return StatusCode(404, MensagensErro.NaoEncontrado);

            }
            return StatusCode(202, CategoriaComProdutoDto.ConverterCategoriasComProdutos(categorias));
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(InsercaoCategoriaDto categoriaDto)
        {
            if (ValidacaoModel(categoriaDto, new InsercaoCategoriaDtoValidation()) is { } erros)
            {
                return StatusCode(403, erros);
            }
            var categoria = InsercaoCategoriaDto.ConverterDto(categoriaDto);
            var categoriaAdicionada = await _categoriaService.AdicionarCategoriaAsync(categoria);
            if(categoriaAdicionada == Guid.Empty)
            {
                return StatusCode(404, MensagensErro.NaoAdicionado);
            }

            return StatusCode(202, categoriaAdicionada);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(AlteracaoCategoriaDto categoriaDto)
        {
            if (ValidacaoModel(categoriaDto, new AlteracaoCategoriaDtoValidation()) is { } erros)
            {
                return StatusCode(403, erros);
            }

            var categoria = AlteracaoCategoriaDto.ConverterDto(categoriaDto);

            var categoriaAdicionada = await _categoriaService.AlterarCategoriaAsync(categoria);

            if (null == categoriaAdicionada)
            {
                return StatusCode(404, MensagensErro.NaoAdicionado);
            }

            return StatusCode(202, CategoriaComProdutoDto.ConverterCategoriaComProdutos(categoria));
        }

        private List<string> ValidacaoModel<T>(T model, IValidator<T> validator) where T : class
        {
            var results = validator.Validate(model);

            if (!results.IsValid)
            {
                return results.Errors.Select(x => x.ErrorMessage).ToList();
            }
            return null;
        }

    }
}