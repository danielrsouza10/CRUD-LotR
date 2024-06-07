using Dominio.Modelos;
using LinqToDB;
using Testes.Interfaces;

namespace Infra.Repositorios;

public class RepositorioRaca : IRepositorio<Raca>
{
    public IEnumerable<Raca> ObterTodos(string nome)
    {
        using var db = new DbOSenhorDosAneis();
        var racas = db.Raca.ToList();
        if (nome != null) return racas.Where(r => r.Nome.ToLower().Contains(nome.ToLower())).ToList();
        return racas;
    }
    public Raca ObterPorId(int id)
    {
        using var db = new DbOSenhorDosAneis();
        var racas = db.Raca;
        return racas.FirstOrDefault(r => r.Id == id);
    }
    public void Criar(Raca raca)
    {
        using var db = new DbOSenhorDosAneis();
        db.Insert(raca);
    }
    public Raca Editar(Raca raca)
    {
        using var db = new DbOSenhorDosAneis();
        var racas = db.Raca.ToList();
        db.Update(raca);
        return racas.FirstOrDefault(r => r.Nome == raca.Nome);
    }
    public void Deletar(int id)
    {
        using var db = new DbOSenhorDosAneis();
        db.Raca
            .Where(r => r.Id == id)
            .Delete();
    }
}