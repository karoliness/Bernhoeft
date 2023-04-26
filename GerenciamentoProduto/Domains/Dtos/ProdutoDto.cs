namespace GerenciamentoProduto.Domains.Dtos
{
    public class ProdutoDto
    {
        public ProdutoDto()
        {
            
        }

        public ProdutoDto(string nome, string descricao, decimal preco, bool situacao)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Situacao = situacao;
        }

        public ProdutoDto(Guid id, string nome, string descricao, decimal preco, bool situacao)
        {
            Id= id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Situacao = situacao;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Situacao { get; set; }

        public static ProdutoDto ConverterProduto(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Situacao = produto.Situacao,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
            };
        }

        public static List<ProdutoDto> ConverterProdutos(List<Produto> produtos)
        {
            var produtosDtos = new List<ProdutoDto> { };

            foreach (var produto in produtos)
            {
                produtosDtos.Add(ProdutoDto.ConverterProduto(produto));
            }

            return produtosDtos;
        }
    }
}
