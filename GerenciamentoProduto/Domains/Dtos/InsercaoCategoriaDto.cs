namespace GerenciamentoProduto.Domains.Dtos
{
    public class InsercaoCategoriaDto : CategoriaDto
    {

        public static Categoria ConverterDto(InsercaoCategoriaDto insercaoCategoriaDto)
        {
            return new Categoria { 
                Id = insercaoCategoriaDto.Id,
                Nome=insercaoCategoriaDto.Nome,
                Situacao=insercaoCategoriaDto.Situacao
            };
        }
    }
}
