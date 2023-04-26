namespace GerenciamentoProduto.Domains.Dtos
{
    public class AlteracaoCategoriaDto : CategoriaDto
    {
        public AlteracaoCategoriaDto()
        {
            
        }
        public static Categoria ConverterDto(AlteracaoCategoriaDto alteracaoCategoriaDto)
        {
            return new Categoria {
                Id= alteracaoCategoriaDto.Id,
                Nome= alteracaoCategoriaDto.Nome,
                Situacao=alteracaoCategoriaDto.Situacao
            };
        }
    }
}
