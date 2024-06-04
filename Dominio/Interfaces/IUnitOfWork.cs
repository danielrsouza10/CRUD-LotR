using System.Dynamic;

namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IRepositorioPersonagem Personagem { get; }
    IRepositorioRaca Raca { get; }
    void Salvar();
}