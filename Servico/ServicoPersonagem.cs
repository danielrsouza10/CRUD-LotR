using Dominio.ENUMS;
using Dominio.Interfaces;
using Dominio.Modelos;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Testes.Singleton;

namespace Dominio.Servicos
{
    public class ServicoPersonagem : IServicoPersonagem
    {
        public Personagem Criar()
        {
            throw new NotImplementedException();
        }

        public Personagem Deletar()
        {
            throw new NotImplementedException();
        }

        public Personagem Editar()
        {
            throw new NotImplementedException();
        }

        public Personagem ObterPorId(int id)
        {
            var personagem = PersonagemSingleton.Instance.Personagens.Find(p => p.Id == id);
            if(personagem == null)
            {
                throw new Exception("O ID informado não existe");
            }
            return personagem;
        }

        public List<Personagem> ObterTodos()
        {
            return PersonagemSingleton.Instance.Personagens;
        }
    }
}
