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
        private const int ID_TESTE = 1;
        const int ID_MAIOR_QUE_EXISTENTE_NA_LISTA = 6;
        private const int ID_MENOR_QUE_ZERO = -1;
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
            servicoRepositorio.CriarListaSingleton();
            //act
            var personagemRetornado = servicoPersonagem.ObterPorId(ID_TESTE);
            //assert
            Assert.Equal(nomePersonagem, personagemRetornado.Nome);
        }
        
        [Fact]
        public void AoObterPorIdUmIdInexistente06_DeveRetornarUmaException()
        {
            //arranje
            servicoRepositorio.CriarListaSingleton();
            //act
            var ex = Assert.Throws<Exception>(() => servicoPersonagem.ObterPorId(ID_MAIOR_QUE_EXISTENTE_NA_LISTA));
            //assert
            Assert.Equal("O ID informado não existe", ex.Message);
        }
        
        [Fact]
        public void AoObterPorIdUmIdMenorQueZero_DeveRetornarUmaException()
        {
            //arranje
            servicoRepositorio.CriarListaSingleton();
            //act
            var ex = Assert.Throws<Exception>(() => servicoPersonagem.ObterPorId(ID_MENOR_QUE_ZERO));
            //assert
            Assert.Equal("O ID tem que ser maior que zero", ex.Message);
        }
    }
}
