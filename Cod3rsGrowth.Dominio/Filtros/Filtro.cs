using Dominio.ENUMS;
using Dominio.Modelos;

namespace Dominio.Filtros;

public class Filtro
{
    public string? NomeDoPersonagem { get; set; }
    public string? NomeDaRaca { get; set; }
    public ProfissaoEnum Profissao { get; set; }
    public bool? EstaVivo { get; set; }
    public bool? EstaExtinta { get; set; }
    public DateTime? DataInicial { get; set; }   
    public DateTime? DataFinal { get; set; }  
}