using Dominio.Modelos;
using System;
using Testes.Interfaces;

namespace Testes.Repositorios
{
    public class RepositorioMockRacas : IRepositorioMock<Raca>
    {

        public List<Raca> ListaDeRacas { get; }

        public List<Raca> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}