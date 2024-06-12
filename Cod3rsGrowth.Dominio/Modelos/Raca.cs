
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
        [Column("Localização Geográfica")]
        public string? LocalizacaoGeografica { get; set; }
        [Column("Habilidade Racial")]
        public string? HabilidadeRacial { get; set; }
        [Column("Raça Extinta?")]
        public bool EstaExtinta {  get; set; }
    }
}

