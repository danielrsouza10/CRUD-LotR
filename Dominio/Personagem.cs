namespace Dominio
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdRaca { get; set; }
        public enum classe {Arqueiro, Guerreiro, Mago, Ladrao, Curandeiro}
        public int Idade { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public DateTime DataDoCadastro { get; set; }

    }
}
