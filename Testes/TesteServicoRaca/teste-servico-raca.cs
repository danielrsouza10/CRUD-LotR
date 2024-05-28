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
    public void AoObterTodos_DeveRetornarUmaListaDeTamanho5()
    {
        //arrange
        var tamanhoEsperadoDaLista = 5;
        //act
        var tamanhoRealDaLista = _servicoRaca.ObterTodos().Count;
        //assert
        Assert.Equal(tamanhoEsperadoDaLista, tamanhoRealDaLista);
    }
}