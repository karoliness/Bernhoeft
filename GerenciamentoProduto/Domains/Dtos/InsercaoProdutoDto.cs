namespace GerenciamentoProduto.Domains.Dtos
{
    public class InsercaoProdutoDto : ProdutoDto
    {
        public InsercaoProdutoDto()
        {
            
        }

        public InsercaoProdutoDto(string nome, string descricao, decimal preco, bool situacao) : base(nome, descricao, preco, situacao)
        {
        }

        public Guid CategoriaId { get; set; }

        public static Produto ConverterDto(InsercaoProdutoDto produtoDto)
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
