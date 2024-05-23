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
        const int ID_TESTE = 1;
        const int ID_MAIOR_QUE_EXISTENTE_NA_LISTA = 100;
        const int ID_MENOR_QUE_ZERO = -1;
        const int TAMANHO_ESPERADO_DA_LISTA = 6;
        const int ID_NOVO_PERSONAGEM = 7;
        private readonly IServicoPersonagem _servicoPersonagem;
        private readonly IRepositorioMock<Personagem> _servicoRepositorio;

        public teste_servico_personagem()
        {
            _servicoPersonagem = _serviceProvider.GetService<IServicoPersonagem>();
            _servicoRepositorio = _serviceProvider.GetService<IRepositorioMock<Personagem>>();
        }

        [Fact]
        public void AoObterTodos_DeveRetornarUmaListaDeTipoPersonagem()
        {
            //act
            var listaDePersonagens = _servicoPersonagem.ObterTodos();
            //assert
            Assert.IsType<List<Personagem>>(listaDePersonagens);
        }

        [Fact]
        public void AoObterPorIdIgual01_DeveRetornarUmPersonagemComNomeAragorn()
        {
            //arrange
            var nomePersonagem = "Aragorn";
            //act
            var personagemRetornado = _servicoPersonagem.ObterPorId(ID_TESTE);
            //assert
            Assert.Equal(nomePersonagem, personagemRetornado.Nome);
        }
        
        [Fact]
        public void AoObterPorIdUmIdInexistente100_DeveRetornarUmaException()
        {
            //act
            var ex = Assert.Throws<Exception>(() => _servicoPersonagem.ObterPorId(ID_MAIOR_QUE_EXISTENTE_NA_LISTA));
            //assert
            Assert.Equal("O ID informado não existe", ex.Message);
        }
        
        [Fact]
        public void AoObterPorIdUmIdMenorQueZero_DeveRetornarUmaException()
        {
            //act
            var ex = Assert.Throws<Exception>(() => _servicoPersonagem.ObterPorId(ID_MENOR_QUE_ZERO));
            //assert
            Assert.Equal("O ID tem que ser maior que zero", ex.Message);
        }
        
        [Fact]
        public void AoCriarUmPersonagemValido_AoObterporIdDeveRetornarUmaId6()
        {
            //arrange
            Personagem personagem = new() { Nome = "Daniel", Profissao = ProfissaoEnum.Guerreiro, IdRaca = 1 };
            _servicoPersonagem.Criar(personagem);
            //act
            var idPersonagem = _servicoRepositorio.ObterPorId(personagem.Id);
            //assert
            Assert.Equal(personagem.Id, idPersonagem.Id);
        }

        [Fact]
        public void AoCriarUmPersonagemComNomeVazio_DeveRetornarUmaExcecao()
        {
            //arranje
            var Lista = PersonagemSingleton.Instance.Personagens;
            Personagem personagem = new() { Profissao = ProfissaoEnum.Guerreiro, IdRaca = 1 };
            //act
            var ex = Assert.Throws<Exception>(() => _servicoPersonagem.Criar(personagem));
            //assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void AoCriarUmPersonagemComComApenas2Caracteres_DeveRetornarUmaExcecao()
        {
            //arranje
            var Lista = PersonagemSingleton.Instance.Personagens;
            Personagem personagem = new() { Nome = "ab", Profissao = ProfissaoEnum.Guerreiro, IdRaca = 1 };
            //act
            var ex = Assert.Throws<Exception>(() => _servicoPersonagem.Criar(personagem));
            //assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void AoCriarUmPersonagemComUmIdDeclaradoManualmente_DeveRetornarUmaExcecao()
        {
            //arranje
            var Lista = PersonagemSingleton.Instance.Personagens;
            Personagem personagem = new() { Nome = "Sam", Id = 9, Profissao = ProfissaoEnum.Ladrao, IdRaca = 4 };
            //act
            var ex = Assert.Throws<Exception>(() => _servicoPersonagem.Criar(personagem));
            //assert
            Assert.IsType<Exception>(ex);
        }
    }
}
