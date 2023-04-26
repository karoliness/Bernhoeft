using GerenciamentoProduto.DataDbContext;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GerenciamentoProduto.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly GerenciamentoProdutoContext dbContext;

        public ProdutoRepository(GerenciamentoProdutoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            await dbContext.Produtos.AddAsync(produto);
            await dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AlterarProduto(Produto produto)
        {
            dbContext.Produtos.Update(produto);
            await dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<List<Produto>> ObterProdutoPorDescricao(string descricao)
        {
            return await dbContext.Produtos.Where(x => x.Descricao.ToLower() == descricao.ToLower()).ToListAsync();
        }

        public async Task<Produto> ObterProdutoPorId(Guid produtoId)
        {
            return await dbContext.Produtos.Where(x => x.Id == produtoId).FirstAsync();
        }

        public async Task<List<Produto>> ObterProdutoPorSituacao(bool situacao)
        {
            return await dbContext.Produtos.Where(x => x.Situacao == situacao).ToListAsync();
        }

        public async Task<List<Produto>> ObterProdutosPorCategoria(string categoria)
        {
            return await dbContext.Produtos.Where(p => p.Categoria.Nome.ToLower() == categoria.ToLower()).ToListAsync();
        }

        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
           return await dbContext.Produtos.Include(p=>p.Categoria).ToListAsync();
        }
    }
}
