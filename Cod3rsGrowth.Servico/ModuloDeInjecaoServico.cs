using Dominio.Validacao;
using Microsoft.Extensions.DependencyInjection;
using Servico.Servicos;

namespace Servico
{
    public class ModuloDeInjecaoServico
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<PersonagemValidacao>();
            services.AddScoped<RacaValidacao>();
            services.AddScoped<ServicoPersonagem>();
            services.AddScoped<ServicoRaca>();
        }
    }
}
