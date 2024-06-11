using Dominio.Modelos;
using LinqToDB;
using Testes.Interfaces;

namespace Infra.Repositorios;
public class RepositorioPersonagem : IRepositorio<Personagem>
{
    private readonly DbOSenhorDosAneis _db;
    public RepositorioPersonagem(DbOSenhorDosAneis db) => _db = db;
    public IEnumerable<Personagem> ObterTodos(string? nome, bool? estaVivo, int? idRaca)
    {
        var personagens = from p in _db.Personagem select p;

        if (estaVivo != null)personagens = from p in personagens where p.EstaVivo select p;
        if (idRaca!= null) personagens = from p in personagens where p.IdRaca==idRaca select p;
        if (nome != null) personagens = from p in personagens where p.Nome.ToLower().Contains(nome.ToLower()) select p;
        
        return personagens.ToList();
    }
    public Personagem ObterPorId(int id)
    {
        var personagens = _db.Personagem;
        return personagens.FirstOrDefault(p => p.Id == id);
    }
    public void Criar(Personagem personagem) => _db.Insert(personagem);
    public Personagem Editar(Personagem personagem)
    {
        var personagens = _db.Personagem.ToList();
        _db.Update(personagem);
        return personagens.FirstOrDefault(p => p.Nome == personagem.Nome);
    }
    public void Deletar(int id)
    {
        _db.Personagem
            .Where(p => p.Id == id)
            .Delete();  
    } 
}