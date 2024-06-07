using Dominio.Modelos;
using LinqToDB;
using Testes.Interfaces;

namespace Infra.Repositorios;
public class RepositorioRaca : IRepositorio<Raca>
{
    private readonly DbOSenhorDosAneis _db;
    public RepositorioRaca (DbOSenhorDosAneis db) => _db = db;
    public IEnumerable<Raca> ObterTodos(string nome)
    {
        var racas = _db.Raca.ToList();
        if (nome != null) return racas.Where(r => r.Nome.ToLower().Contains(nome.ToLower())).ToList();
        return racas;
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