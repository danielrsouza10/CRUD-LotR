using Dominio;
using Microsoft.Extensions.DependencyInjection;
using Testes.Repositorios;

namespace Testes
{
    public class ModuloDeInjecao
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddSingleton<IRepositorioMock<Personagem>, RepositorioMockPersonagens>();
        }
    }
}
