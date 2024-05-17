using Dominio.Modelos;

namespace Testes.Singleton
{
    public sealed class RacaSingleton
    {
        private static RacaSingleton instance = null;

        public List<Raca> Racas { get; set; }

        private RacaSingleton()
        {
            Racas = new List<Raca>() {
                new Raca(1, "Humano"),
                new Raca(2, "Elfo"),
                new Raca(3, "Anão"),
                new Raca(4, "Maiar"),
                new Raca(5, "Hobbit")
            };
        }
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