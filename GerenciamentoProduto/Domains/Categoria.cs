namespace GerenciamentoProduto.Domains
{
    public class Categoria
    {
        public Categoria()
        {
        }

        public Categoria(string nome, bool situacao)
        {
            Nome = nome;
            Situacao = situacao;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Situacao { get; set; }
        public List<Produto> Produtos { get; } = new();


    }
}
