using Dominio.Interfaces;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Infra.Repositorios;

public class RepositorioRaca : IRepositorio<Raca>
{
    public List<Raca> ObterTodos(string nome)
    {
        using var db = new DbOSenhorDosAneis();
        var racas = db.Raca.ToList();
        if (nome != null)
        {
            return racas.Where(r => r.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }
        return racas;
    }

    public Raca ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void Criar(Raca raca)
    {
        throw new NotImplementedException();
    }

    public Raca Editar(Raca raca)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }
}