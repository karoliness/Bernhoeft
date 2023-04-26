using GerenciamentoProduto.DataDbContext;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GerenciamentoProduto.Repositories
{
    public class CategoriaRepository: ICategoriaRepository
    {
        private readonly GerenciamentoProdutoContext dbContext;

        public CategoriaRepository(GerenciamentoProdutoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Categoria> AdicionarCategoriaAsync(Categoria categoria)
        {
            await dbContext.Categorias.AddAsync(categoria);
            await dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> AlterarCategoriaAsync(Categoria categoria )
        {
            dbContext.Categorias.Update(categoria);
            await dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<List<Categoria>> ObterCategoriasPorNomeAsync(string nome)
        {
            return await dbContext.Categorias.Where(x => x.Nome.ToLower() == nome.ToLower()).ToListAsync();
        }

        public async Task<List<Categoria>> ObterCategoriasPorSituacaoAsync(bool situacao)
        {
            return await dbContext.Categorias.Where(x => x.Situacao == situacao).ToListAsync();
        }

        public async Task<List<Categoria>> ObterTodasAsCategorias()
        {
            return await dbContext.Categorias.Include(c => c.Produtos).ToListAsync();
        }
    }
}
