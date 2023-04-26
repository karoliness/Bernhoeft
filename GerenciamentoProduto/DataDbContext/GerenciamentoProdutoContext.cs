using GerenciamentoProduto.Domains;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace GerenciamentoProduto.DataDbContext
{
    public class GerenciamentoProdutoContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("store");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Produtos)
                .WithOne(e => e.Categoria)
                .HasForeignKey(e=>e.CategoriaId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
