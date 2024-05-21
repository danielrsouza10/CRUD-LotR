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
            //var list = new List<Personagem>
            //{
            //    new Personagem(1, "Aragorn", 1, ProfissaoEnum.Guerreiro),
            //    new Personagem(2, "Legolas", 2, ProfissaoEnum.Arqueiro),
            //    new Personagem(3, "Guimli", 3, ProfissaoEnum.Guerreiro),
            //    new Personagem(3, "Gandalf", 4, ProfissaoEnum.Mago)
            //};
            //return list;
            return PersonagemSingleton.Instance.Personagens;
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
