﻿namespace GerenciamentoProduto.Domains.Dtos
{
    public class CategoriaDto
    {
        public CategoriaDto()
        {
            
        }
        public CategoriaDto(string nome, bool situacao)
        {
            Nome = nome;
            Situacao = situacao;
        }

        public CategoriaDto(Guid id, string nome, bool situacao)
        {
            Id = id;
            Nome = nome;
            Situacao = situacao;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Situacao { get; set; }



        public static CategoriaDto ConverterCategoria(Categoria categoria)
        {
            return new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Situacao = categoria.Situacao
            };

        }

        public static List<CategoriaDto> ConverterCategorias(List<Categoria> categorias)
        {
            var categoriasDtos = new List<CategoriaDto>() { };

            foreach (var categoria in categorias)
            {
                categoriasDtos.Add(ConverterCategoria(categoria));
            }
            return categoriasDtos;
        }

    }
}
