using Dominio.Filtros;
using Dominio.Modelos;
using LinqToDB;
using LinqToDB.Common;
using Testes.Interfaces;

namespace Infra.Repositorios;
public class RepositorioPersonagem : IRepositorio<Personagem>
{
    private readonly DbOSenhorDosAneis _db;
    public RepositorioPersonagem(DbOSenhorDosAneis db) => _db = db;
    public IEnumerable<Personagem> ObterTodos(Filtro filtro)
    {
        var personagens = from p in _db.Personagem select p;
        
        if (filtro == null) return personagens.ToList();
        
        if (!string.IsNullOrEmpty(filtro.Nome)) personagens = from p in personagens where p.Nome.ToLower().Contains(filtro.Nome.ToLower()) select p;
        if (!filtro.Id.Equals(null)) personagens = from p in personagens where p.Id == filtro.Id select p;
        if (!filtro.EstaVivo.Equals(null)) personagens = from p in personagens where p.EstaVivo == filtro.EstaVivo select p;
        if (!filtro.DataDoCadastro.Equals(null)) personagens = from p in personagens where p.DataDoCadastro == filtro.DataDoCadastro select p;
        
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
    public bool VerificarNomeNoDb(string nome)
    {
        return _db.Personagem
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                    .ToList().IsNullOrEmpty();
    }
}