using Dominio.ENUMS;
using LinqToDB.Mapping;

namespace Dominio.Modelos
{
    [Table("Personagem")]
    public class Personagem
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("NomePersonagem"), NotNull]
        public string Nome { get; set; }
        [Column, NotNull]
        public int IdRaca { get; set; }
        [Column, NotNull]
        public ProfissaoEnum Profissao { get; set; }
        [Column]
        public int? Idade { get; set; }
        [Column]
        public float? Altura { get; set; }
        [Column]
        public DateTime DataDoCadastro { get; set; }

        public Personagem() {
            DataDoCadastro = DateTime.Now;
        }

      
    }
}
