using Dominio.Modelos;
using System;
using Testes.Interfaces;
using Testes.Singleton;

namespace Testes.Repositorios
{
    public class RepositorioMockRacas : IRepositorioMock<Raca>
    {

        private List<Raca> _listaDeRacas = RacaSingleton.Instance.Racas;

        public List<Raca> ObterTodos()
        {
            return _listaDeRacas;
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}