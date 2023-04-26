using GerenciamentoProduto.Domains.Dtos;

namespace GerenciamentoProduto.Domains
{
    public class Produto
    {
        public Produto()
        {
        }

        public Produto(string nome, string descricao, decimal preco, bool situacao, Categoria categoria)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Situacao = situacao;
            Categoria = categoria;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Situacao { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; } = null!;


    }
}
