using Dominio.Modelos;
using System;
using Testes.Interfaces;

namespace Testes.Repositorios
{
    public class RepositorioMockRacas : IRepositorioMock<Raca>
    {

        public List<Raca> ListaDeRacas { get; }

        public List<Raca> CriarListaSingleton()
        {
            throw new NotImplementedException();
        }

        public List<Raca> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Personagem ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Personagem Criar()
        {
            throw new NotImplementedException();
        }

        public Personagem Editar()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }
    }
}