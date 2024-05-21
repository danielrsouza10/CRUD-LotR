using Dominio.ENUMS;
using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Interfaces;
using Testes.Singleton;


namespace Testes.TesteServicoPersonagem
{
    public class teste_servico_personagem : TesteBase
    {

        const int TAMANHO_ESPERADO_DA_LISTA = 4;
        private readonly IServicoPersonagem servicoPersonagem;
        private readonly IRepositorioMock<Personagem> servicoRepositorio;

        public teste_servico_personagem()
        {
            servicoPersonagem = _serviceProvider.GetService<IServicoPersonagem>();
            servicoRepositorio = _serviceProvider.GetService<IRepositorioMock<Personagem>>();
        }

        [Fact]
        public void AoObterTodos_DeveRetornarUmaListaDeTipoPersonagem()
        {
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.IsType<List<Personagem>>(listaDePersonagens);
        }

        [Fact]
        public void AoObterTodos_DeveRetornarUmaListaVazia()
        {
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.Empty(listaDePersonagens);
        }

        [Fact]
        public void AoObterTodos_DeveRetornarUmaListaCom3Itens()
        {
            const int quantidadeItens = 3;
            var personagemSingleton = PersonagemSingleton.Instance;
            var ListaPersonagens = new List<Personagem>
            {
                new() {Id = 1, Nome = "Aragorn", IdRaca = 1, Profissao = ProfissaoEnum.Guerreiro},
                new() {Id = 1, Nome = "Aragorn", IdRaca = 1, Profissao = ProfissaoEnum.Guerreiro},
                new() {Id = 1, Nome = "Aragorn", IdRaca = 1, Profissao = ProfissaoEnum.Guerreiro},

            };
            personagemSingleton.Personagens.AddRange(ListaPersonagens);
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.Equal(quantidadeItens, listaDePersonagens.Count);
        }

        [Fact]
        public void DeveRetornarUmaListaDeTamanhoIgualADaListaDeclaradaNoTeste()
        {
            //arranje
            var lista = servicoRepositorio.CriarListaSingleton();

            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();

            //assert
            Assert.Equal(TAMANHO_ESPERADO_DA_LISTA, listaDePersonagens.Count);
        }

        [Fact]
        public void DeveRetornarUmaListaIgualAListaDeclaradaNoTeste()
        {
            //arranje
            //var personagemSingleton = PersonagemSingleton.Instance.Personagens;
            //personagemSingleton.Add(new(1, "Aragorn", 1, ProfissaoEnum.Guerreiro));
            //personagemSingleton.Add(new(2, "Legolas", 2, ProfissaoEnum.Arqueiro));
            //personagemSingleton.Add(new(3, "Gandalf", 3, ProfissaoEnum.Mago));
            //personagemSingleton.Add(new(4, "Gimli", 4, ProfissaoEnum.Guerreiro));
            ////act
            //var listaDePersonagens = servicoPersonagem.ObterTodos();
            ////assert
            //Assert.Equivalent(personagemSingleton, listaDePersonagens);
        }

        [Fact]
        public void DeveRetornarUmPersonagemComNomeAragorn()
        {
            //arranje
            var nomePersonagem = "Aragorn";
            //act
            var personagemRetornado = servicoPersonagem.ObterPorId(1);
            //assert
            Assert.Equal(nomePersonagem, personagemRetornado.Nome);
        }
        [Fact]
        public void DeveRetornarUmPersonagemComNomeLegolas()
        {
            //arranje
            var nomePersonagem = "Legolas";
            //act
            var personagemRetornado = servicoPersonagem.ObterPorId(2);
            //assert
            Assert.Equal(nomePersonagem, personagemRetornado.Nome);
        }
        [Fact]
        public void DeveRetornarUmPersonagemComNomeGandalf()
        {
            //arranje
            var nomePersonagem = "Gandalf";
            //act
            var personagemRetornado = servicoPersonagem.ObterPorId(3);
            //assert
            Assert.Equal(nomePersonagem, personagemRetornado.Nome);
        }
    }
}
