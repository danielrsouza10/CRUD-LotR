using Dominio.Validacao;
using Microsoft.Extensions.DependencyInjection;
using Servico.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
