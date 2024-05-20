using Dominio.ENUMS;
using Dominio.Modelos;
using System.Runtime.CompilerServices;

namespace Testes.Singleton
{
    public sealed class PersonagemSingleton
    {
        private static PersonagemSingleton instance = null;

        public List<Personagem> Personagens { get; set; }

        private PersonagemSingleton() {
            Personagens = new List<Personagem>()
            {
                new (1, "Aragorn", 1, ProfissaoEnum.Guerreiro),
                new (2, "Legolas", 2, ProfissaoEnum.Arqueiro),
                new (3, "Guimli", 3, ProfissaoEnum.Guerreiro),
                new (3, "Gandalf", 4, ProfissaoEnum.Mago)
            };
            
        }

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
        public void Initialize() {}  
    }
}