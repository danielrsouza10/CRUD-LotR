namespace Dominio
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdRaca { get; set; }
        public Raca Raca { get; set; }
        public ProfissaoEnum Profissao { get; set; }
        public int? Idade { get; set; }
        public float? Altura { get; set; }
        public DateTime DataDoCadastro { get; set; }

    }
}
