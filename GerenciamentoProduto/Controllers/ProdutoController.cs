using FluentValidation;
using GerenciamentoProduto.DataDbContext;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;
using GerenciamentoProduto.Services;
using GerenciamentoProduto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GerenciamentoProduto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<CategoriaController> logger, IProdutoService produtoService)
        {
            _logger = logger;   
            _produtoService = produtoService;
        }


        [HttpGet("obter")]
        public async Task<IActionResult> ObterTodosOsProdutos()
        {
            var produtos = await _produtoService.ObterTodosOsProdutos();

            if (!produtos.Any())
            {
                return StatusCode(404, MensagensErro.NaoEncontrado);

            }

            var buscarProdutoDto = BuscaProdutoDto.ConverterProdutosComCategoria(produtos);
            
            return StatusCode(202, buscarProdutoDto);
        }

        [HttpGet("situacao/{situacao}")]
        public async Task<IActionResult> ObterPorSituacao([FromRoute] bool situacao)
        {
            var produtos = await _produtoService.ObterProdutoPorSituacao(situacao);

            if (!produtos.Any())
            {
                return StatusCode(404, MensagensErro.NaoEncontrado);

            }
            var buscarProdutoDto = BuscaProdutoDto.ConverterProdutosComCategoria(produtos);

            return StatusCode(202, buscarProdutoDto);
        }

        [HttpGet("descricao/{descricao}")]
        public async Task<IActionResult> ObterPorDescricao([FromRoute] string descricao)
        {
            var produtos = await _produtoService.ObterProdutoPorDescricao(descricao);

            if (!produtos.Any())
            {
                return StatusCode(404, MensagensErro.NaoEncontrado);

            }
            var buscarProdutoDto = BuscaProdutoDto.ConverterProdutosComCategoria(produtos);

            return StatusCode(202, buscarProdutoDto);
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(InsercaoProdutoDto produtoDto)
        {

            if (ValidacaoModel(produtoDto, new InsercaoProdutoDtoValidation()) is {} erros)
            {
                return StatusCode(403, erros);
            }
            
            var produto = InsercaoProdutoDto.ConverterDto(produtoDto);
            var produtoAdicionado = await _produtoService.AdicionarProduto(produto);
            if (produtoAdicionado == Guid.Empty)
            {
                return StatusCode(404, MensagensErro.NaoAdicionado);
            }

            return StatusCode(202, produtoAdicionado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(AlteracaoProdutoDto produtoDto)
        {
            if (ValidacaoModel(produtoDto, new AlteracaoProdutoDtoValidation()) is { } erros)
            {
                return StatusCode(403, erros);
            }

            var produto = AlteracaoProdutoDto.ConverterDto(produtoDto);
            var produtoAtualizado = await _produtoService.AlterarProduto(produto);
            if (null == produtoAtualizado)
            {
                return StatusCode(404, MensagensErro.NaoAdicionado);
            }

            var buscarProdutoDto = BuscaProdutoDto.ConverterProdutoComCategoria(produto);

            return StatusCode(202, buscarProdutoDto);
        }


        private List<string> ValidacaoModel<T>(T model, IValidator<T> validator) where T : class
        {
            var results = validator.Validate(model);

            if (!results.IsValid)
            {
                return results.Errors.Select(x=>x.ErrorMessage).ToList();
            }
            return null;
        }
    }
}
