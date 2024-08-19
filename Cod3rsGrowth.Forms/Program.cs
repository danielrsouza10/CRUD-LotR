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
using Servico;
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
            
            var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");
            return Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                   ModuloDeInjecaoInfra.BindServices(services, connectionString);
                   ModuloDeInjecaoServico.BindServices(services);
                });
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}