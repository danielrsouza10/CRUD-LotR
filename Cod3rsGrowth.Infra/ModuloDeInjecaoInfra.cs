using LinqToDB;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB.AspNet;
using Dominio.Modelos;
using Dominio.Validacao;
using Servico.Servicos;
using Testes.Interfaces;
using Infra.Repositorios;
using FluentMigrator.Runner;
using Infra.Migrations;

namespace Infra;

public class ModuloDeInjecaoInfra
{
    public static void BindServices(IServiceCollection services, string connectionString)
    {
        services.AddScoped<IRepositorio<Personagem>, RepositorioPersonagem>();
        services.AddScoped<IRepositorio<Raca>, RepositorioRaca>();

        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("A variavel de ambiente SQLSERVER_CONNECTION_STRING não está definida");
        }
        services.AddLinqToDBContext<DbOSenhorDosAneis>((provider, options) => options.UseSqlServer(connectionString));
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer().WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(AddPersonagemTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }
}