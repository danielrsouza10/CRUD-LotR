namespace Dominio.Filtros;

public class Filtro
{
    public string? Nome { get; set; }
    public int? Id { get; set; }
    public bool? EstaVivo { get; set; }
    public bool? EstaExtinta { get; set; }
    public DateTime? DataDoCadastro { get; set; }   
}