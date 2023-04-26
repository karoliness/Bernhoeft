namespace GerenciamentoProduto.Domains.Dtos
{
    public class ProdutoComCategoriaDto : ProdutoDto
    {
        public CategoriaDto Categoria { get; set; }


        public static ProdutoComCategoriaDto ConverterProdutoComCategoria(Produto produto)
        {
            return new ProdutoComCategoriaDto
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Nome = produto.Nome,
                Situacao = produto.Situacao,
                Categoria = CategoriaDto.ConverterCategoria(produto.Categoria)
            };
        }


        public static List<ProdutoComCategoriaDto> ConverterProdutosComCategoria(List<Produto> produtos)
        { 
            var buscarProdutosDto = new List<ProdutoComCategoriaDto>();

            foreach (var produto in produtos)
            {
                buscarProdutosDto.Add(ConverterProdutoComCategoria(produto));
            }

            return buscarProdutosDto;
        }
    }
}
