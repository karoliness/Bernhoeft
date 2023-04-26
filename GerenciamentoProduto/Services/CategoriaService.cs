using GerenciamentoProduto.DataDbContext;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Repositories.Interfaces;
using GerenciamentoProduto.Services.Interfaces;

namespace GerenciamentoProduto.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }
        public async Task<Guid> AdicionarCategoriaAsync(Categoria categoria)
        {
            var categoriaCriada = await this.categoriaRepository.AdicionarCategoriaAsync(categoria);
            return categoriaCriada.Id;
        }

        public Task<Categoria> AlterarCategoriaAsync(Categoria categoria)
        {
            return this.categoriaRepository.AlterarCategoriaAsync(categoria);

        }

        public Task<List<Categoria>> ObterCategoriasPorNomeAsync(string nome)
        {
            return this.categoriaRepository.ObterCategoriasPorNomeAsync(nome);
        }

        public Task<List<Categoria>> ObterCategoriasPorSituacaoAsync(bool situacao)
        {
            return this.categoriaRepository.ObterCategoriasPorSituacaoAsync(situacao);
        }

        public Task<List<Categoria>> ObterTodasAsCategorias()
        {
            return this.categoriaRepository.ObterTodasAsCategorias();
        }
    }
}
