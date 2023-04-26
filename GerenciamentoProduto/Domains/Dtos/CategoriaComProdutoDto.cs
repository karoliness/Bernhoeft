using System.Reflection.Metadata.Ecma335;

namespace GerenciamentoProduto.Domains.Dtos
{
    public class CategoriaComProdutoDto : CategoriaDto
    {
        public List<ProdutoDto> Produtos { get; set; }

        public static CategoriaComProdutoDto ConverterCategoriaComProdutos(Categoria categoria)
        {
            return new CategoriaComProdutoDto
            {
                Produtos = ProdutoDto.ConverterProdutos(categoria.Produtos),
                Id = categoria.Id,
                Nome = categoria.Nome,
                Situacao = categoria.Situacao,
            };
        }

        public static List<CategoriaComProdutoDto> ConverterCategoriasComProdutos(List<Categoria> categorias)
        {
            var buscaCategoriasDto = new List<CategoriaComProdutoDto>();

            foreach (var categoria in categorias)
            {
                buscaCategoriasDto.Add(CategoriaComProdutoDto.ConverterCategoriaComProdutos(categoria));
            }
            return buscaCategoriasDto;
        }
    }
}
