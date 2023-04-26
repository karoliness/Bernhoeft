using FluentValidation;
using GerenciamentoProduto.DataDbContext;
using GerenciamentoProduto.Domains;
using GerenciamentoProduto.Domains.Dtos;
using GerenciamentoProduto.Domains.Validations;
using GerenciamentoProduto.Repositories;
using GerenciamentoProduto.Repositories.Interfaces;
using GerenciamentoProduto.Services;
using GerenciamentoProduto.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
.AddTransient<GerenciamentoProdutoContext>()
.AddTransient<ICategoriaRepository, CategoriaRepository>()
.AddTransient<IProdutoRepository, ProdutoRepository>()
.AddTransient<IProdutoService, ProdutoService>()
.AddTransient<ICategoriaService, CategoriaService>()
.AddTransient<IValidator<InsercaoProdutoDto>, InsercaoProdutoDtoValidation>()
.AddTransient<IValidator<AlteracaoProdutoDto>, AlteracaoProdutoDtoValidation>()
.AddTransient<IValidator<InsercaoCategoriaDto>, InsercaoCategoriaDtoValidation>()
.AddTransient<IValidator<AlteracaoCategoriaDto>, AlteracaoCategoriaDtoValidation>()
.AddTransient<IValidator<ProdutoDto>, ProdutoDtoValidation<ProdutoDto>>()
.AddTransient<IValidator<CategoriaDto>, CategoriaDtoValidation<CategoriaDto>>()
;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

GerenciamentoProdutoContext db = app.Services.GetService<GerenciamentoProdutoContext>() ?? throw new InvalidOperationException($"{nameof(GerenciamentoProdutoContext)} null in startup.");

await db.Database.EnsureCreatedAsync();

app.Run();
