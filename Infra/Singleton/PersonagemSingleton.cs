using Dominio.Modelos;

namespace Testes.Singleton
{
    public sealed class PersonagemSingleton
    {
        private static PersonagemSingleton instance = null;


        public List<Personagem> Personagens { get; set; }

        private PersonagemSingleton() {
            Personagens = new List<Personagem>(); 
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
        public void Initialize(){}  
    }
}