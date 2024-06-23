using Dominio.Modelos;
using Dominio.Validacao;
using FluentMigrator.Runner;
using Infra;
using Infra.Migrations;
using Infra.Repositorios;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
           ApplicationConfiguration.Initialize();

           var host = CreateHostBuilder().Build();
           ServiceProvider = host.Services;
           
            
            using (var scope = ServiceProvider.CreateScope())
            {
                try
                {
                    UpdateDatabase(scope.ServiceProvider);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha na migração do banco de dados. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           Application.Run(new MainForm(ServiceProvider.GetRequiredService<ServicoPersonagem>(), ServiceProvider.GetRequiredService<ServicoRaca>()));
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

                    var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");
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
                });
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}