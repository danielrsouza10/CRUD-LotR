
using LinqToDB.Mapping;

namespace Dominio.Modelos
{
    [Table("Raca")]
    public class Raca
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("NomeRaca"), NotNull]
        public string Nome { get; set; }
        [Column]
        public string? LocalizacaoGeografica { get; set; }
        [Column]
        public string? HabilidadeRacial { get; set; }
    }
}

