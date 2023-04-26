namespace GerenciamentoProduto.Domains.Dtos
{
    public class InsercaoCategoriaDto : CategoriaDto
    {

        public InsercaoCategoriaDto()
        {
            
        }

        public InsercaoCategoriaDto(string nome, bool situacao) : base(nome, situacao)
        {
        }

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
