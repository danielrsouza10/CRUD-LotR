using Dominio.ENUMS;
using Dominio.Interfaces;
using Dominio.Modelos;
using System.Diagnostics.CodeAnalysis;
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

        public Personagem ObterPorId()
        {
            throw new NotImplementedException();
        }

        public List<Personagem> ObterTodos()
        {
            return PersonagemSingleton.Instance.Personagens;
        }
    }
}
