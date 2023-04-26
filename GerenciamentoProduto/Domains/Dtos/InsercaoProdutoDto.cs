namespace GerenciamentoProduto.Domains.Dtos
{
    public class InsercaoProdutoDto : ProdutoDto
    {
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
