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
            return new List<Personagem>();
            //return PersonagemSingleton.Instance.Personagens;
        }

        public class CompararListaDePersonagens : IEqualityComparer<Personagem>
        {
            public bool Equals(Personagem? x, Personagem? y)
            {
                if(Object.ReferenceEquals(x,y)) return true;
                if (Object.ReferenceEquals(x, null)) return false;

                return x.Nome == y.Nome;
            }

            public int GetHashCode([DisallowNull] Personagem obj)
            {
                if(Object.ReferenceEquals(obj, null)) return 0;

                int hashName = obj.Nome == null ? 0 : obj.Nome.GetHashCode();
                
                return hashName;
            }
        }
    }
}
