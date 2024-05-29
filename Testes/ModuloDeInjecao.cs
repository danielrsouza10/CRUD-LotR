using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Repositorios;
using Testes.Interfaces;
using Dominio.Validacao;
using Servico.Servicos;

namespace Testes
{
    public class ModuloDeInjecao
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<ServicoPersonagem>();
            services.AddScoped<ServicoRaca>();
            services.AddScoped<IRepositorioMock<Personagem>, RepositorioMockPersonagens>();
            services.AddScoped<IRepositorioMock<Raca>, RepositorioMockRacas>();
            services.AddScoped<PersonagemValidacao>();
            services.AddScoped<RacaValidacao>();

        }
    }
}
