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

        public Personagem ObterPorId(int id)
        {
            var personagem = new Personagem();
            if(id == 1) {
                personagem.Id = id;
                personagem.Nome = "Aragorn";
            }
            else if(id == 2)
            {
                personagem.Id = id;
                personagem.Nome = "Legolas";
            } else if(id == 3)
            {
                personagem.Id = id;
                personagem.Nome = "Gandalf";
            }
            return personagem;
        }

        public List<Personagem> ObterTodos()
        {
            return PersonagemSingleton.Instance.Personagens;
        }
    }
}
