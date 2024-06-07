
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Servico.Servicos;
using Testes.Interfaces;
using Testes.Singleton;

namespace Testes.TesteServicos;

public class teste_servico_raca : TesteBase
{
    private readonly ServicoRaca _servicoRaca;
    private readonly IRepositorio<Raca> _servicoRepositorio;

    public teste_servico_raca()
    {
        _servicoRaca = _serviceProvider.GetService<ServicoRaca>();
        _servicoRepositorio = _serviceProvider.GetService<IRepositorio<Raca>>();
    }

    [Fact]
    public void AoObterTodos_DeveRetornarUmaListaTipoRaca()
    {
        var nome = "";
        //act
        var listaDeRacas = _servicoRaca.ObterTodos(nome);
        //assert
        Assert.IsType<List<Raca>>(listaDeRacas);
    }

    [Fact]
    public void AoObterTodos_DeveRetornarUmaListaEquivalenteAListaMockada()
    {
        var nome = "";
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
        var listaMockada = _servicoRaca.ObterTodos(nome);
        //assert
        Assert.Equivalent(listaDeRacas, listaMockada);
    }
    [Fact]
    public void AoObterPorId_DeveRetornarUmaRacaIgualNaListaMockada()
    {
        //arrange
        var humano = "Humano";
        var idHumano = 1;
        var elfo = "Elfo";
        var idElfo = 2;
        var anao = "Anao";
        var idAnao = 3;
        //act
        var humanoEncontrado = _servicoRaca.ObterPorId(idHumano).Nome;
        var elfoEncontrado = _servicoRaca.ObterPorId(idElfo).Nome;
        var anaoEncontrado = _servicoRaca.ObterPorId(idAnao).Nome;
        //assert
        Assert.Equal(humano, humanoEncontrado);
        Assert.Equal(elfo, elfoEncontrado);
        Assert.Equal(anao, anaoEncontrado);
    }

    [Fact]
    public void AoObterPorIdIgualA0_DeveRetornarUmaExcecao()
    {
        //arrange
        var idBusca = 0;
        var mensagemErro = "O ID deve ser maior que zero";
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.ObterPorId(idBusca));
        //assert
        Assert.Equal(mensagemErro, ex.Message);
    }

    [Fact]
    public void AoObterPorIdIgualQueNaoExisteNaLista_DeveRetornarUmaExcecao()
    {
        //arrange
        var idBusca = 100;
        var mensagemErro = "O ID informado não existe";
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.ObterPorId(idBusca));
        //assert
        Assert.Equal(mensagemErro, ex.Message);
    }

    [Fact]
    public void AoCriarUmaRacaValida_DeveSerCapazDeAcharONomeDaNovaRacaNoRepositorio()
    {
        //arrange
        var novaRaca = new Raca() { Nome = "Orc" };
        //act
        _servicoRaca.Criar(novaRaca);
        var nomeNovaRacaNoRepositorio = RacaSingleton.Instance.Racas.Find(r => r.Nome == novaRaca.Nome).Nome;
        //assert
        Assert.Equal(novaRaca.Nome, nomeNovaRacaNoRepositorio);
    }
    [Fact]
    public void AoCriarUmaRacaComNomeVazio_DeveRetornarUmaExcecao()
    {
        //arrange
        var novaRaca = new Raca() { LocalizacaoGeografica = "Goiania" };
        var mensagemDeErro = "O nome da raça não pode ser null. Precisa informar um nome para a raça. ";
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Criar(novaRaca));
        //assert
        Assert.Equal(mensagemDeErro, ex.Message);
    }
    [Fact]
    public void AoCriarUmaRacaComNomeNull_DeveRetornarUmaExcecao()
    {
        //arrange
        var novaRaca = new Raca() { Nome = null, HabilidadeRacial = "Imunidade a veneno" };
        var mensagemDeErro = "O nome da raça não pode ser null. Precisa informar um nome para a raça. ";
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Criar(novaRaca));
        //assert
        Assert.Equal(mensagemDeErro, ex.Message);
    }
    [Fact]
    public void AoCriarUmaRacaComNomeDeApenas2Caracteres_DeveRetornarUmaExcecao()
    {
        //arrange
        var novaRaca = new Raca() { Nome = "or" };
        var mensagemDeErro = "O nome da raça precisa ter entre 3 e 25 caracteres. ";
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Criar(novaRaca));
        //assert
        Assert.Equal(mensagemDeErro, ex.Message);
    }
    [Fact]
    public void AoCriarUmaRacaComIdDeclaradoManualmente_DeveRetornarUmaExcecao()
    {
        //arrange
        var novaRaca = new Raca() { Nome = "Orc", Id = 1 };
        var mensagemDeErro = "Não deve ser informado um Id. ";
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Criar(novaRaca));
        //assert
        Assert.Equal(mensagemDeErro, ex.Message);
    }
    [Fact]
    public void AoCriarUmaRacaComIdDeclaradoManualmenteENomeComMenosDe2Caracteres_DeveRetornarUmaExcecaoComOTextoDosDoisErros()
    {
        //arrange
        var novaRaca = new Raca() { Nome = "Or", Id = 1 };
        var mensagemDeErro = "O nome da raça precisa ter entre 3 e 25 caracteres. Não deve ser informado um Id. ";
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Criar(novaRaca));
        //assert
        Assert.Equal(mensagemDeErro, ex.Message);
    }

    [Fact]
    public void AoEditarUmaRacaComIdValido_DeveRetornarARacaComOsDadosAtualizados()
    {
        //arrange
        var raca = new Raca() { Id = 1, HabilidadeRacial = "Domar feras" };
        var nomeRaca = "Humano";
        //act
        var racaEditada = _servicoRaca.Editar(raca);
        //assert
        Assert.Equal(racaEditada.HabilidadeRacial, racaEditada.HabilidadeRacial);
        Assert.Equal(nomeRaca, racaEditada.Nome);
    }
    [Fact]
    public void AoEditarUmaRacaComUmNomeDeApenas2Caracteres_DeveRetornarUmaExcecao()
    {
        //arranje
        var mensagemErro = "O nome da raça precisa ter entre 3 e 25 caracteres. ";
        Raca raca = new() { Id = 1, Nome = "ab" };
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Editar(raca));
        //assert
        Assert.IsType<Exception>(ex);
        Assert.Equal(mensagemErro, ex.Message);
    }
    [Fact]
    public void AoEditarUmaRacaComIdInexistente_DeveRetornarUmaExcecao()
    {
        //arranje
        var mensagemErro = "O ID informado não existe";
        Raca raca = new() { Id = 6, Nome = "Orc" };
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Editar(raca));
        //assert
        Assert.IsType<Exception>(ex);
        Assert.Equal(mensagemErro, ex.Message);
    }
    [Fact]
    public void AoEditarUmaRacaComId0_DeveRetornarUmaExcecao()
    {
        //arranje
        var mensagemErro = "O ID informado não existe";
        Raca raca = new() { Id = 0, Nome = "Trolls" };
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Editar(raca));
        //assert
        Assert.IsType<Exception>(ex);
        Assert.Equal(mensagemErro, ex.Message);
    }
    [Fact]
    public void AoExcluirUmaRacaComId0_DeveRetornarUmaExcecao()
    {
        //arranje
        var mensagemErro = "O ID informado não existe";
        var idPersonagem = 0;
        //act
        var ex = Assert.Throws<Exception>(() => _servicoRaca.Deletar(idPersonagem));
        //assert
        Assert.IsType<Exception>(ex);
        Assert.Equal(mensagemErro, ex.Message);
    }
    [Fact]
    public void AoExcluirUmaRacaComId1_DeveRetornarUmaListaMenorQueAInicial()
    {
        //arranje
        var idPersonagem = 4;
        var quantidadeDePersonagensRemovidos = 1;
        var tamanhoPrevistoDaLista = RacaSingleton.Instance.Racas.Count - quantidadeDePersonagensRemovidos;
        //act
        _servicoRaca.Deletar(idPersonagem);
        var tamanhoFinalDaLista = RacaSingleton.Instance.Racas.Count;
        //assert
        Assert.Equal(tamanhoPrevistoDaLista, tamanhoFinalDaLista);
        RacaSingleton.Instance.Racas.Add(new Raca() { Id = 4, Nome = "Maiar", HabilidadeRacial = "Poder mágico aumentado", LocalizacaoGeografica = "Valinor" });
    }
}