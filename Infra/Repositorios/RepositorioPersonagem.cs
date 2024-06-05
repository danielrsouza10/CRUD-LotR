using Dominio.Interfaces;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Infra.Repositorios;

public class RepositorioPersonagem : IRepositorio<Personagem>
{
    public List<Personagem> ObterTodos(string nome)
    {
        var db = new DbOSenhorDosAneis();
        List<Personagem> personagens = new List<Personagem>();
        if (nome != null)
        {
           personagens = (from personagem in db.Personagem where personagem.Nome.Contains(nome.ToLower()) select personagem).ToList();
        }
        return personagens;
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
}