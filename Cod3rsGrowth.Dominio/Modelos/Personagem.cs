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
        [Column("Nome Personagem"), NotNull]
        public string Nome { get; set; }
        [Association(ThisKey = nameof(IdRaca), OtherKey = nameof(Raca.Id))]
        public int IdRaca { get; set; }
        [Column("Profissão"), NotNull]
        public ProfissaoEnum Profissao { get; set; }
        [Column("Idade")]
        public int? Idade { get; set; }
        [Column("Altura")]
        public float? Altura { get; set; }
        [Column("Esta vivo?"), NotNull]
        public bool EstaVivo { get; set; }
        [Column("Data do Cadastro")]
        public DateTime DataDoCadastro { get; set; }
        public Personagem()
        {
            DataDoCadastro = DateTime.Now;
        }
    }
}
