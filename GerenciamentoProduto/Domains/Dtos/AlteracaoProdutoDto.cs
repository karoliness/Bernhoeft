namespace GerenciamentoProduto.Domains.Dtos
{
    public class AlteracaoProdutoDto : ProdutoDto
    {
        public AlteracaoProdutoDto()
        {
        }

        public AlteracaoProdutoDto(string nome, string descricao, decimal preco, bool situacao) : base(nome, descricao, preco, situacao)
        {
        }

        public AlteracaoProdutoDto(Guid id, string nome, string descricao, decimal preco, bool situacao) : base(id, nome, descricao, preco, situacao)
        {
        }

        public Guid CategoriaId { get; set; }

        public static Produto ConverterDto(AlteracaoProdutoDto produtoDto)
        {
            return new Produto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                Preco = produtoDto.Preco,
                Situacao = produtoDto.Situacao,
                CategoriaId = produtoDto.CategoriaId
            };


        }
    }
}
