using Dominio.Interfaces;
using Dominio.Modelos;
using LinqToDB;
using System.Collections;
using System.Diagnostics.Contracts;
using Testes.Interfaces;

namespace Infra.Repositorios;

public class RepositorioPersonagem : IRepositorio<Personagem>
{
    private readonly DbOSenhorDosAneis _db;
    public RepositorioPersonagem(DbOSenhorDosAneis db)
    {
        _db = db; 
    }
    public IEnumerable<Personagem> ObterTodos(string nome)
    {
        var personagens = _db.Personagem.ToList();
        if (nome != null)
        {
            //var x =  (from Personagem personagem 
            //         in personagens 
            //         where personagem.Nome.ToLower().Contains(nome.ToLower()) 
            //         select personagem).ToList();

           return personagens.Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }
        return personagens;
    }
    public Personagem ObterPorId(int id)
    {
        using var db = new DbOSenhorDosAneis();
        var personagens = db.Personagem;
        return personagens.FirstOrDefault(p => p.Id == id);
    }
    public void Criar(Personagem personagem)
    {
        using var db = new DbOSenhorDosAneis();
        db.Insert(personagem);
    }
    public Personagem Editar(Personagem personagem)
    {
        using var db = new DbOSenhorDosAneis();
        var personagens = db.Personagem.ToList();
        db.Update(personagem);
        return personagens.FirstOrDefault(p => p.Nome == personagem.Nome);
    }
    public void Deletar(int id)
    {
        using var db = new DbOSenhorDosAneis();
        db.Personagem
            .Where(p => p.Id == id)
            .Delete();
    }
}