using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Repositorios;
using Testes.Interfaces;
using Dominio.Servicos;
using Dominio.Interfaces;
using Dominio.Validacao;

namespace Testes
{
    public class ModuloDeInjecao
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<IServicoPersonagem, ServicoPersonagem>();
            services.AddScoped<IServicoRaca, ServicoRaca>();
            services.AddScoped<IRepositorioMock<Personagem>, RepositorioMockPersonagens>();
            services.AddScoped<IRepositorioMock<Raca>, RepositorioMockRacas>();
            services.AddScoped<PersonagemValidacao>();
            services.AddScoped<RacaValidacao>();

        }
    }
}
