using Dominio.ENUMS;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Testes.Repositorios
{
    public class RepositorioMockPersonagens : IRepositorioMock<Personagem>
    {
        private List<Personagem> ListaDePersonagens { get; }
        public RepositorioMockPersonagens()
        {

            ListaDePersonagens = new List<Personagem>()
        {
            new Personagem(1, "Aragorn", 1, ProfissaoEnum.Guerreiro),
            new Personagem(2, "Legolas", 2, ProfissaoEnum.Arqueiro),
            new Personagem(3, "Guimli", 3, ProfissaoEnum.Guerreiro),
            new Personagem(4, "Gandalf", 4, ProfissaoEnum.Mago),
            new Personagem(5, "Sam", 5, ProfissaoEnum.Ladrao),
        };
        }

        public List<Personagem> ObterTodos()
        {
            return ListaDePersonagens;
        }
    }
}