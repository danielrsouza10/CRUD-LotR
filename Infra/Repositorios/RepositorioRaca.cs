using Dominio.Interfaces;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Infra.Repositorios;

public class RepositorioRaca : IRepositorio<Raca>
{
    public List<Raca> ObterTodos(string nome)
    {
        var db = new DbOSenhorDosAneis();
        var racas = from raca in db.Raca select raca;
        racas = from raca in racas where raca.Nome.Contains(nome.ToLower()) select raca;
        return racas.ToList();
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