using Dominio.Filtros;
using Dominio.Modelos;
using LinqToDB;
using Testes.Interfaces;

namespace Infra.Repositorios;
public class RepositorioRaca : IRepositorio<Raca>
{
    private readonly DbOSenhorDosAneis _db;
    public RepositorioRaca (DbOSenhorDosAneis db) => _db = db;
    public IEnumerable<Raca> ObterTodos(Filtro filtro)
    {
        var racas = from r in _db.Raca select r;

        if(filtro == null) return racas.ToList();

        if (!string.IsNullOrEmpty(filtro.Nome)) racas = from r in racas where r.Nome.ToLower().Contains(filtro.Nome.ToLower()) select r;
        if (!filtro.Id.Equals(null)) racas = from r in racas where r.Id == filtro.Id select r;
        if (!filtro.EstaExtinta.Equals(null)) racas = from r in racas where r.EstaExtinta == filtro.EstaExtinta select r;

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