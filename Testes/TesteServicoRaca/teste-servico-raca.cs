using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Interfaces;
using Testes.Singleton;
using Testes.TestesRepositorio;

namespace Testes.TesteServicoRaca;

public class teste_servico_raca : TesteBase
{
    private readonly IServicoRaca _servicoRaca;
    private readonly IRepositorioMock<Raca> _servicoRepositorio;

    public teste_servico_raca()
    {
        _servicoRaca = _serviceProvider.GetService<IServicoRaca>();
        _servicoRepositorio = _serviceProvider.GetService<IRepositorioMock<Raca>>();
    }

    [Fact]
    public void AoObterTodos_DeveRetornarUmaListaTipoRaca()
    {
        //act
        var listaDeRacas = _servicoRaca.ObterTodos();
        //assert
        Assert.IsType<List<Raca>>(listaDeRacas);
    }

    [Fact]
    public void AoObterTodos_DeveRetornarUmaListaEquivalenteAListaMockada()
    {
        //arrange
        List<Raca> listaDeRacas = new()
        {
            new Raca { Id = 1, Nome = "Humano", LocalizacaoGeografica = "Gondor", HabilidadeRacial = "Nenhuma"},
            new Raca { Id = 2, Nome = "Elfo", LocalizacaoGeografica = "Lóthlorien", HabilidadeRacial = "Visão Noturna"},
            new Raca { Id = 3, Nome = "Anao", LocalizacaoGeografica = "Moria", HabilidadeRacial = "Resistencia a Magia"},
            new Raca { Id = 4, Nome = "Maiar", LocalizacaoGeografica = "Valinor", HabilidadeRacial = "Poder mágico aumentado"},
            new Raca { Id = 5, Nome = "Hobbit", LocalizacaoGeografica = "Condado", HabilidadeRacial = "Evasão aumentada"}
        };
        //act
        var listaMockada = _servicoRaca.ObterTodos();
        //assert
        Assert.Equivalent(listaDeRacas, listaMockada);
    }
}