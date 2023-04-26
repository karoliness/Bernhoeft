namespace GerenciamentoProduto.Domains.Dtos
{
    public class BuscaProdutoDto : ProdutoDto
    {
        public CategoriaDto Categoria { get; set; }


        public static BuscaProdutoDto ConverterProdutoComCategoria(Produto produto)
        {
            return new BuscaProdutoDto
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Nome = produto.Nome,
                Situacao = produto.Situacao,
                Categoria = CategoriaDto.ConverterCategoria(produto.Categoria)
            };
        }


        public static List<BuscaProdutoDto> ConverterProdutosComCategoria(List<Produto> produtos)
        { 
            var buscarProdutosDto = new List<BuscaProdutoDto>();

            foreach (var produto in produtos)
            {
                buscarProdutosDto.Add(ConverterProdutoComCategoria(produto));
            }

            return buscarProdutosDto;
        }
    }
}
