using GerenciamentoProduto.Domains;

namespace GerenciamentoProduto.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Guid> AdicionarProduto(Produto produto);
        Task<Produto> AlterarProduto(Produto produto);
        Task<List<Produto>> ObterProdutosPorCategoria(string categoria);
        Task<List<Produto>> ObterProdutoPorSituacao(bool situacao);
        Task<List<Produto>> ObterProdutoPorDescricao(string descricao);
        Task<List<Produto>> ObterTodosOsProdutos();
    }
}
