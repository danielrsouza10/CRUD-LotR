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

        public void Criar(Personagem personagem)
        {
            throw new NotImplementedException();
        }

        public Personagem Editar(Personagem personagem)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Personagem personagem)
        {
            throw new NotImplementedException();
        }
    }
}