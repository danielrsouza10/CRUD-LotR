using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Interfaces;
using Testes.Repositorios;

namespace Testes
{
    public class ModuloDeInjecao
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddSingleton<RepositorioMockPersonagens>();
            services.AddScoped<RepositorioMockPersonagens>();
            services.AddTransient<RepositorioMockPersonagens>();
        }
    }
}
