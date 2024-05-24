using Dominio.ENUMS;
using Dominio.Modelos;
using Testes.Interfaces;
using Testes.Singleton;

namespace Testes.Repositorios
{
    public class RepositorioMockPersonagens : IRepositorioMock<Personagem>
    {
        private List<Personagem> ListaDePersonagens = PersonagemSingleton.Instance.Personagens;
        

        public List<Personagem> ObterTodos()
        {
            return ListaDePersonagens;
        }

        public Personagem ObterPorId(int id)
        {
            return ListaDePersonagens.Find(p => p.Id == id) ?? throw new Exception("O ID informado não existe");
        }

        public void Criar(Personagem personagem)
        {
            var incrementoParaOId = 1;
            personagem.Id = PersonagemSingleton.Instance.Personagens.Max(p => p.Id) + incrementoParaOId;
            ListaDePersonagens.Add(personagem);
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