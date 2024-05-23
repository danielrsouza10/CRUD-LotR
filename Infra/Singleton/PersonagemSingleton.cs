using Dominio.ENUMS;
using Dominio.Modelos;

namespace Testes.Singleton
{
    public sealed class PersonagemSingleton
    {
        private static PersonagemSingleton instance = null;

        public List<Personagem> Personagens = new List<Personagem>() {
            new Personagem { Id = 1, Nome = "Aragorn", IdRaca = 1, Profissao = ProfissaoEnum.Guerreiro },
            new Personagem { Id = 2, Nome = "Legolas", IdRaca = 2, Profissao = ProfissaoEnum.Arqueiro },
            new Personagem { Id = 3, Nome = "Gandalf", IdRaca = 3, Profissao = ProfissaoEnum.Mago },
            new Personagem { Id = 4, Nome = "Gimli", IdRaca = 4, Profissao = ProfissaoEnum.Guerreiro },
            new Personagem { Id = 5, Nome = "Frodo", IdRaca = 5, Profissao = ProfissaoEnum.Ladrao }
        };

        private PersonagemSingleton() { }
        

        public static PersonagemSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonagemSingleton();
                }
                return instance;
            }
        }
        public void Initialize() { }
    }
}