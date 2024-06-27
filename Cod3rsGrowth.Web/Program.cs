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

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer().WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(AddPersonagemTable).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole())
    .BuildServiceProvider(false);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PersonagemValidacao>();
builder.Services.AddScoped<RacaValidacao>();
builder.Services.AddScoped<ServicoPersonagem>();
builder.Services.AddScoped<ServicoRaca>();
builder.Services.AddScoped<IRepositorio<Personagem>, RepositorioPersonagem>();
builder.Services.AddScoped<IRepositorio<Raca>, RepositorioRaca>();
builder.Services.AddLinqToDBContext<DbOSenhorDosAneis>((provider, options) => options.UseSqlServer(connectionString));

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
