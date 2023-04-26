using GerenciamentoProduto.Domains;

namespace GerenciamentoProduto.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> AdicionarProduto(Produto produto);
        Task<Produto> AlterarProduto(Produto produto);
        Task<List<Produto>> ObterProdutosPorCategoria(string categoria);
        Task<List<Produto>> ObterProdutoPorSituacao(bool situacao);
        Task<List<Produto>> ObterProdutoPorDescricao(string descricao);
        Task<Produto> ObterProdutoPorId(Guid produtoId);
        Task<List<Produto>> ObterTodosOsProdutos();
    }
}
