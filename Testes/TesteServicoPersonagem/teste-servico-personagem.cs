using Dominio.ENUMS;
using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Testes.Singleton;

namespace Testes.TesteServicoPersonagem
{
    public class teste_servico_personagem : TesteBase
    {

        const int TAMANHO_ESPERADO_DA_LISTA = 4;
        private readonly IServicoPersonagem servicoPersonagem;

        public teste_servico_personagem()
        {
            servicoPersonagem = _serviceProvider.GetService<IServicoPersonagem>();
        }

        [Fact]
        public void DeveRetornarUmaListaDeTipoPersonagem()
        {
            //arrange
            var lista = new List<Personagem>();
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.Equal(lista, listaDePersonagens);
        }

        [Fact]
        public void DeveRetornarUmaListaDeTamanhoIgualADaListaDeclaradaNoTeste()
        {
            //arranje
            var personagemSingleton = PersonagemSingleton.Instance.Personagens;
            personagemSingleton.Add(new(1, "Aragorn", 1, ProfissaoEnum.Guerreiro));
            personagemSingleton.Add(new(1, "Aragorn", 1, ProfissaoEnum.Guerreiro));
            personagemSingleton.Add(new(1, "Aragorn", 1, ProfissaoEnum.Guerreiro));
            personagemSingleton.Add(new(1, "Aragorn", 1, ProfissaoEnum.Guerreiro));

            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();

            //assert
            Assert.Equal(TAMANHO_ESPERADO_DA_LISTA, listaDePersonagens.Count);
        }

        [Fact]
        public void DeveRetornarUmaListaIgualAListaDeclaradaNoTeste()
        {
            //arranje
            var personagemSingleton = PersonagemSingleton.Instance.Personagens;
            personagemSingleton.Add( new (1, "Aragorn", 1, ProfissaoEnum.Guerreiro));
            personagemSingleton.Add(new(2, "Legolas", 2, ProfissaoEnum.Arqueiro));
            personagemSingleton.Add(new(3, "Gandalf", 3, ProfissaoEnum.Mago));
            personagemSingleton.Add(new(4, "Gimli", 4, ProfissaoEnum.Guerreiro));
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.Equivalent(personagemSingleton, listaDePersonagens);
        }

        //[Fact]
        //public void asdf()
        //{
        //    var personagens = PersonagemSingleton.Instance;

        //    var a = personagens.Personagens;

        //    Assert.NotNull(a);
        //    Assert.Equal(TAMANHO_ESPERADO_DA_LISTA, a.Count);

        //}


        //[Fact]
        //public void asd33f()
        //{
        //    var personagens = PersonagemSingleton.Instance;
        //    var a = personagens.Personagens;
        //    a.Add(new Personagem());

        //    Assert.NotNull(a);
        //    Assert.Equal(TAMANHO_ESPERADO_DA_LISTA, a.Count);
        //}
    }
}
