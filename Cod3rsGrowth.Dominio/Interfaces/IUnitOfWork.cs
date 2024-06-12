using System.Dynamic;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IRepositorio<Personagem> Personagem { get; }
    IRepositorio<Raca> Raca { get; }
    void Salvar();
}