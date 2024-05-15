using Dominio;
using System;

public class RepositorioMock : IRepositorioMock
{
    private List<Personagem> ListaDePersonagens { get; }
    private List<Raca> ListaDeRacas { get; }
    public RepositorioMock()
    {

        ListaDePersonagens = new List<Personagem>()
        {
            new Personagem(1, "Aragorn", 1, ProfissaoEnum.Guerreiro),
            new Personagem(2, "Legolas", 2, ProfissaoEnum.Arqueiro),
            new Personagem(3, "Guimli", 3, ProfissaoEnum.Guerreiro),
            new Personagem(4, "Gandalf", 4, ProfissaoEnum.Mago),
            new Personagem(5, "Sam", 5, ProfissaoEnum.Ladrao),
        };

        ListaDeRacas = new List<Raca>()
        {
            new Raca(1, "Humano"),
            new Raca(2, "Elfo"),
            new Raca(3, "Anão"),
            new Raca(4, "Maiar"),
            new Raca(5, "Hobbit")
        };
    }

    public List<Personagem> ObterTodosOsPersonagens()
    {
        throw new NotImplementedException();
    }

    public List<Raca> ObterTodasAsRacas()
    {
        throw new NotImplementedException();
    }
}
