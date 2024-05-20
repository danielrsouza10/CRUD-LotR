﻿using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Repositorios;
using Testes.Interfaces;
using Dominio.Servicos;
using Dominio.Interfaces;

namespace Testes
{
    public class ModuloDeInjecao
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<IServicoPersonagem, ServicoPersonagem>();
        }
    }
}
