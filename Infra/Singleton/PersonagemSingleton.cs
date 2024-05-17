namespace Testes.Singleton
{
    public sealed class PersonagemSingleton
    {
        private static PersonagemSingleton instance = null;

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
    }
}