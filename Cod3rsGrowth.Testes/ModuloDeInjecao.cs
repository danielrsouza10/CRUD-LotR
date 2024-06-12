using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Repositorios;
using Testes.Interfaces;
using Dominio.Validacao;
using Servico.Servicos;
using Infra;

namespace Testes
{
    public class ModuloDeInjecao
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<ServicoPersonagem>();
            services.AddScoped<ServicoRaca>();
            services.AddScoped<IRepositorio<Personagem>, RepositorioMockPersonagens>();
            services.AddScoped<IRepositorio<Raca>, RepositorioMockRacas>();
            services.AddScoped<PersonagemValidacao>();
            services.AddScoped<RacaValidacao>();
        }
    }
}
