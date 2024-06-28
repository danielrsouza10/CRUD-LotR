using Dominio.Modelos;
using Dominio.Validacao;
using FluentMigrator.Runner;
using Infra.Migrations;
using Infra;
using Infra.Repositorios;
using Servico.Servicos;
using Testes.Interfaces;
using LinqToDB.AspNet;
using LinqToDB;
using Servico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ModuloDeInjecaoInfra.BindServices(builder.Services);
ModuloDeInjecaoServico.BindServices(builder.Services);

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

app.Run();
