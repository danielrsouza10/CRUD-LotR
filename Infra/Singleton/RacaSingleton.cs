namespace Testes.Singleton
{
    public sealed class RacaSingleton
    {
        private static RacaSingleton instance = null;

        private RacaSingleton() { }

        public static RacaSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RacaSingleton();
                }
                return instance;
            }
        }
    }
}