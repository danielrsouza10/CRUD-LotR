using Dominio.ENUMS;
using Dominio.Filtros;
using Dominio.Modelos;
using LinqToDB;
using Newtonsoft.Json.Linq;
using System;
using Testes.Interfaces;

namespace Infra.Repositorios;
public class RepositorioPersonagem : IRepositorio<Personagem>
{
    private readonly DbOSenhorDosAneis _db;
    public RepositorioPersonagem(DbOSenhorDosAneis db) => _db = db;
    public IEnumerable<Personagem> ObterTodos(Filtro filtro)
    {
        var personagens = from p in _db.Personagem select p;

        if (filtro != null)
        {
            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                personagens = from p in personagens where p.Nome.ToLower().Contains(filtro.Nome.ToLower()) select p;
            }

            if (filtro.Profissao != ProfissaoEnum.Nenhum)
            {
                personagens = from p in personagens where p.Profissao == filtro.Profissao select p;
            }

            if (filtro.EstaVivo.HasValue)
            {
                personagens = from p in personagens where p.EstaVivo == filtro.EstaVivo select p;
            }

            if (filtro.DataInicial.HasValue)
            {
                personagens = from p in personagens where p.DataDoCadastro.Date >= filtro.DataInicial.Value select p;
            }

            if (filtro.DataFinal.HasValue)
            {
                personagens = from p in personagens where p.DataDoCadastro.Date <= filtro.DataFinal.Value select p;
            }
        }

        var racas = from r in _db.Raca select r;

        var listaDePersonagens = from personagem in personagens
                             join raca in racas on personagem.IdRaca equals raca.Id
                             select new Personagem
                             {
                                 Id = personagem.Id,
                                 Nome = personagem.Nome,
                                 IdRaca = raca.Id,
                                 Raca = raca.Nome,
                                 Profissao = personagem.Profissao,
                                 Idade = personagem.Idade,
                                 Altura = personagem.Altura,
                                 EstaVivo = personagem.EstaVivo,
                                 DataDoCadastro = personagem.DataDoCadastro
                             };

        return listaDePersonagens.ToList();
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
    public bool VerificarNomeNoDb(string nome, int? id = null)
    {
        if (id.HasValue)
        {
            return _db.Personagem
                        .Any(p => p.Nome.ToLower() == nome.ToLower() && p.Id != id.Value);
        }
        return _db.Personagem
                        .Any(p => p.Nome.ToLower().Equals(nome.ToLower()));
    }
}