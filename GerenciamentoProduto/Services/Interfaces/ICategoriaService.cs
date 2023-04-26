using GerenciamentoProduto.Domains;

namespace GerenciamentoProduto.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<Guid> AdicionarCategoriaAsync(Categoria categoria);
        Task<Categoria> AlterarCategoriaAsync(Categoria categoria);
        Task<List<Categoria>> ObterCategoriasPorSituacaoAsync(bool situacao);
        Task<List<Categoria>> ObterTodasAsCategorias();
        Task<List<Categoria>> ObterCategoriasPorNomeAsync(string nome);
    }
}
