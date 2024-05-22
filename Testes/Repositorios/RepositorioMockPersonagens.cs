using Dominio.ENUMS;
using Dominio.Interfaces;
using Dominio.Modelos;
using Testes.Interfaces;
using Testes.Singleton;

namespace Testes.Repositorios
{
    public class RepositorioMockPersonagens : IRepositorioMock<Personagem>
    {
        private List<Personagem> ListaDePersonagens = PersonagemSingleton.Instance.Personagens;
        

        public List<Personagem> CriarListaSingleton()
        {
            List<Personagem> novaLista = new()
            {
                new Personagem { Id = 1, Nome = "Aragorn", IdRaca = 1, Profissao = ProfissaoEnum.Guerreiro },
                new Personagem { Id = 2, Nome = "Legolas", IdRaca = 2, Profissao = ProfissaoEnum.Arqueiro },
                new Personagem { Id = 3, Nome = "Gandalf", IdRaca = 3, Profissao = ProfissaoEnum.Mago },
                new Personagem { Id = 4, Nome = "Gimli", IdRaca = 4, Profissao = ProfissaoEnum.Guerreiro },
                new Personagem { Id = 5, Nome = "Frodo", IdRaca = 5, Profissao = ProfissaoEnum.Ladrao }
            };
            ListaDePersonagens.AddRange(novaLista);
            return ListaDePersonagens;
        }

        public List<Personagem> ObterTodos()
        {
            return PersonagemSingleton.Instance.Personagens;;
        }

        public Personagem ObterPorId(int id)
        {
            return PersonagemSingleton.Instance.Personagens.Find(p => p.Id == id) ?? throw new Exception("O ID informado não existe");
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