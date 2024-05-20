using Dominio.ENUMS;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Testes.Repositorios
{
    public class RepositorioMockPersonagens : IRepositorioMock<Personagem>
    {
        private List<Personagem> ListaDePersonagens { get; }

        public List<Personagem> ObterTodos()
        {
            return ListaDePersonagens;
        }
    }
}