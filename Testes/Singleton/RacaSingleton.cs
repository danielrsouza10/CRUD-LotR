using Dominio.Modelos;

namespace Testes.Singleton
{
    public sealed class RacaSingleton
    {
        private static RacaSingleton instance = null;

        public List<Raca> Racas = new()
        {
            new Raca { Id = 1, Nome = "Humano", LocalizacaoGeografica = "Gondor", HabilidadeRacial = "Nenhuma"},
            new Raca { Id = 2, Nome = "Elfo", LocalizacaoGeografica = "Lóthlorien", HabilidadeRacial = "Visão Noturna"},
            new Raca { Id = 3, Nome = "Anao", LocalizacaoGeografica = "Moria", HabilidadeRacial = "Resistencia a Magia"},
            new Raca { Id = 4, Nome = "Maiar", LocalizacaoGeografica = "Valinor", HabilidadeRacial = "Poder mágico aumentado"},
            new Raca { Id = 5, Nome = "Hobbit", LocalizacaoGeografica = "Condado", HabilidadeRacial = "Evasão aumentada"}
        };

        private RacaSingleton(){ }
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
        public void Initialize() { }
    }
}