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
            ModuloDeInjecaoServico.BindServices(services);
            ModuloDeInjecaoInfra.BindServices(services);
            services.AddScoped<IRepositorio<Personagem>, RepositorioMockPersonagens>();
            services.AddScoped<IRepositorio<Raca>, RepositorioMockRacas>();
        }
    }
}
