using Dominio.Modelos;
using Dominio.Validacao;
using FluentMigrator.Runner;
using Infra;
using Infra.Migrations;
using Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Servico.Servicos;
using Testes.Interfaces;

namespace Forms
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
           ApplicationConfiguration.Initialize();
           var host = CreateHostBuilder().Build();
           ServiceProvider = host.Services;
           
           Application.Run(new MainForm());
            
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                    services.AddScoped<PersonagemValidacao>();
                    services.AddScoped<RacaValidacao>();
                    services.AddScoped<ServicoPersonagem>();
                    services.AddScoped<ServicoRaca>();
                    services.AddScoped<DbOSenhorDosAneis>();
                    services.AddScoped<IRepositorio<Personagem>, RepositorioPersonagem>();
                    services.AddScoped<IRepositorio<Raca>, RepositorioRaca>();
                });
        }
        private static ServiceProvider CreateServices()
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer().WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(AddPersonagemTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}