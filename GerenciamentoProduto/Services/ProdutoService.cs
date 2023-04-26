using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Repositories.Interfaces;
using GerenciamentoProduto.Services.Interfaces;

namespace GerenciamentoProduto.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }
        public async Task<Guid> AdicionarProduto(Produto produto)
        {
            var produtoAdicionado = await this.produtoRepository.AdicionarProduto(produto);
            return produtoAdicionado.Id;
        }

        public async Task<Produto> AlterarProduto(Produto produto)
        {
           return await this.produtoRepository.AlterarProduto(produto);
        }

        public async Task<List<Produto>> ObterProdutoPorDescricao(string descricao)
        {
            return await this.produtoRepository.ObterProdutoPorDescricao(descricao);
        }

        public async Task<List<Produto>> ObterProdutoPorSituacao(bool situacao)
        {
            return await this.produtoRepository.ObterProdutoPorSituacao(situacao);
        }

        public async Task<List<Produto>> ObterProdutosPorCategoria(string categoria)
        {
            return await this.produtoRepository.ObterProdutosPorCategoria(categoria);
        }

        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
            return await this.produtoRepository.ObterTodosOsProdutos();
        }

    }
}
