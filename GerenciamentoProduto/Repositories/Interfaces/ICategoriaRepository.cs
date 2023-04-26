using GerenciamentoProduto.Domains;

namespace GerenciamentoProduto.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> AdicionarCategoriaAsync(Categoria categoria);
        Task<Categoria> AlterarCategoriaAsync(Categoria categoria);
        Task<List<Categoria>> ObterTodasAsCategorias();

        Task<List<Categoria>> ObterCategoriasPorSituacaoAsync(bool situacao);
        Task<List<Categoria>> ObterCategoriasPorNomeAsync(string nome);
    }
}
