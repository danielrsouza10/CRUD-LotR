using Dominio.Interfaces;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Infra.Repositorios;

public class RepositorioPersonagem : IRepositorioPersonagem
{
    public List<Personagem> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Personagem ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void Criar(Personagem t)
    {
        throw new NotImplementedException();
    }

    public Personagem Editar(Personagem t)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Personagem> ObterPersonagensPorRaca(Raca raca)
    {
        throw new NotImplementedException();
    }
}