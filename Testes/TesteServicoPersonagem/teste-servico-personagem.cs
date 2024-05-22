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
            //arrange
            var Lista = PersonagemSingleton.Instance.Personagens;
            Lista.Clear();
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.Empty(listaDePersonagens);
        }

        [Fact]
        public void AoObterTodos_DeveRetornarUmaListaCom5Itens()
        {
            //arrange
            const int quantidadeItens = 5;
            servicoRepositorio.CriarListaSingleton();
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            
            //assert
            Assert.Equal(quantidadeItens, listaDePersonagens.Count);
        }

        [Fact]
        public void AoObterPorIdIgual01_DeveRetornarUmPersonagemComNomeAragorn()
        {
            //arranje
            var nomePersonagem = "Aragorn";
            //cria uma lista singleton no repositorio
            servicoRepositorio.CriarListaSingleton();
            //act
            var personagemRetornado = servicoPersonagem.ObterPorId(1);
            //assert
            Assert.Equal(nomePersonagem, personagemRetornado.Nome);
        }
        [Fact]
        public void AoObterPorIdIgual02_DeveRetornarUmPersonagemComNomeLegolas()
        {
            //arranje
            var nomePersonagem = "Legolas";
            //cria uma lista singleton no repositorio
            servicoRepositorio.CriarListaSingleton();
            //act
            var personagemRetornado = servicoPersonagem.ObterPorId(2);
            //assert
            Assert.Equal(nomePersonagem, personagemRetornado.Nome);
        }
        [Fact]
        
        public void AoObterPorIdUmIdInexistente06_DeveRetornarUmaException()
        {
            //arranje
            //cria uma lista singleton no repositorio
            servicoRepositorio.CriarListaSingleton();
            //act
            var ex = Assert.Throws<Exception>(() => servicoPersonagem.ObterPorId(6));
  
            //assert
            Assert.Equal("O ID informado não existe", ex.Message);
        }
    }
}
