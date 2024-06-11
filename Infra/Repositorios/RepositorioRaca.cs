using Dominio.Modelos;
using LinqToDB;
using Testes.Interfaces;

namespace Infra.Repositorios;
public class RepositorioRaca : IRepositorio<Raca>
{
    private readonly DbOSenhorDosAneis _db;
    public RepositorioRaca (DbOSenhorDosAneis db) => _db = db;
    public IEnumerable<Raca> ObterTodos(string? nome, bool? estaExtinta, int? id)
    {
        var racas = from p in _db.Raca select p;

        if (estaExtinta != null) racas = from p in racas where p.EstaExtinta select p;
        if (id != null) racas = from p in racas where p.Id == id select p;
        if (nome != null) racas = from p in racas where p.Nome.ToLower().Contains(nome.ToLower()) select p;

        return racas.ToList();
    }
    public Raca ObterPorId(int id)
    {
        var racas = _db.Raca;
        return racas.FirstOrDefault(r => r.Id == id);
    }
    public void Criar(Raca raca) => _db.Insert(raca);
    public Raca Editar(Raca raca)
    {
        var racas = _db.Raca.ToList();
        _db.Update(raca);
        return racas.FirstOrDefault(r => r.Nome == raca.Nome);
    }
    public void Deletar(int id)
    {
        _db.Raca
            .Where(r => r.Id == id)
            .Delete();
    }
}