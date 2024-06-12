using Dominio.ENUMS;
using LinqToDB.Mapping;
using System.Numerics;

namespace Dominio.Modelos
{
    [Table("Personagem")]
    public class Personagem
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("Nome"), NotNull]
        public string Nome { get; set; }
        [Association(ThisKey = nameof(IdRaca), OtherKey = nameof(Raca.Id))]
        public int IdRaca { get; set; }
        [Column("Profissao"), NotNull]
        public ProfissaoEnum Profissao { get; set; }
        [Column("Idade")]
        public int? Idade { get; set; }
        [Column("Altura")]
        public float? Altura { get; set; }
        [Column("EstaVivo"), NotNull]
        public bool EstaVivo { get; set; }
        [Column("DataDoCadastro")]
        public DateTime DataDoCadastro { get; set; }
        public Personagem()
        {
            DataDoCadastro = DateTime.Now;
        }
    }
}
