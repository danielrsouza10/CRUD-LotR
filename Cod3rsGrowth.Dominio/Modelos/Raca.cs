
using LinqToDB.Mapping;

namespace Dominio.Modelos
{
    [Table("Raca")]
    public class Raca
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("Nome"), NotNull]
        public string Nome { get; set; }
        [Column("LocalizacaoGeografica")]
        public string? LocalizacaoGeografica { get; set; }
        [Column("HabilidadeRacial")]
        public string? HabilidadeRacial { get; set; }
        [Column("EstaExtinta")]
        public bool EstaExtinta {  get; set; }
    }
}

