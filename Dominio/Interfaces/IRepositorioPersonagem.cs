using Dominio.Modelos;
using Testes.Interfaces;

namespace Dominio.Interfaces;

public interface IRepositorioPersonagem : IRepositorio<Personagem>
{
    IEnumerable<Personagem> ObterPersonagensPorRaca(Raca raca);
}