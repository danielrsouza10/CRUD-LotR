using System.Reflection;
using Dominio.ENUMS;
using Dominio.Modelos;
using Testes.Interfaces;
using Testes.Singleton;

namespace Testes.Repositorios
{
    public class RepositorioMockPersonagens : IRepositorioMock<Personagem>
    {
        private List<Personagem> _listaDePersonagens = PersonagemSingleton.Instance.Personagens;
        public List<Personagem> ObterTodos() => _listaDePersonagens;
        public void Deletar(int id) => _listaDePersonagens.Remove(ObterPorId(id));
        public Personagem ObterPorId(int id) => _listaDePersonagens.Find(p => p.Id == id) ?? throw new Exception("O ID informado não existe");
        public void Criar(Personagem personagem)
        {
            const int IncrementoParaONovoId = 1;
            personagem.Id = _listaDePersonagens.Any() ? _listaDePersonagens.Max(p => p.Id) + IncrementoParaONovoId : IncrementoParaONovoId;
            _listaDePersonagens.Add(personagem);
        }
        public Personagem Editar(Personagem personagem)
        {
            var personagemExistente = ObterPorId(personagem.Id);
            if(personagem.Nome != null) personagemExistente.Nome = personagem.Nome;
            if(personagem.Profissao != null) personagemExistente.Profissao = personagem.Profissao;
            if(personagem.IdRaca != null) personagemExistente.IdRaca = personagem.IdRaca;
            if(personagem.Idade != null) personagemExistente.Idade = personagem.Idade;
            if(personagem.Altura != null) personagemExistente.Altura = personagem.Altura;
   
            return personagemExistente;
        }
    }
}