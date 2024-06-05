using Dominio.Interfaces;
using Dominio.Modelos;
using System.Collections;
using Testes.Interfaces;

namespace Infra.Repositorios;

public class RepositorioPersonagem : IRepositorio<Personagem>
{
    public List<Personagem> ObterTodos(string nome)
    {
        using var db = new DbOSenhorDosAneis();
        var personagens = db.Personagem.ToList();
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