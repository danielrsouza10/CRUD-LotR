using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Repositorios;
using Testes.Interfaces;
using Dominio.Validacao;
using Servico.Servicos;
using Infra;
using Servico;

namespace Testes
{
    public class ModuloDeInjecaoTestes
    {
        public static void BindServices(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING_TESTE");
            ModuloDeInjecaoServico.BindServices(services);
            ModuloDeInjecaoInfra.BindServices(services, connectionString);
            services.AddScoped<IRepositorio<Personagem>, RepositorioMockPersonagens>();
            services.AddScoped<IRepositorio<Raca>, RepositorioMockRacas>();
        }
    }
}
