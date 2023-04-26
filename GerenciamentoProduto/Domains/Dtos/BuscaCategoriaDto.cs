using System.Reflection.Metadata.Ecma335;

namespace GerenciamentoProduto.Domains.Dtos
{
    public class BuscaCategoriaDto : CategoriaDto
    {
        public List<ProdutoDto> Produtos { get; set; }

        public static BuscaCategoriaDto ConverterCategoriaComProdutos(Categoria categoria)
        {
            return new BuscaCategoriaDto
            {
                Produtos = ProdutoDto.ConverterProdutos(categoria.Produtos),
                Id = categoria.Id,
                Nome = categoria.Nome,
                Situacao = categoria.Situacao,
            };
        }

        public static List<BuscaCategoriaDto> ConverterCategoriasComProdutos(List<Categoria> categorias)
        {
            var buscaCategoriasDto = new List<BuscaCategoriaDto>();

            foreach (var categoria in categorias)
            {
                buscaCategoriasDto.Add(BuscaCategoriaDto.ConverterCategoriaComProdutos(categoria));
            }
            return buscaCategoriasDto;
        }
    }
}
