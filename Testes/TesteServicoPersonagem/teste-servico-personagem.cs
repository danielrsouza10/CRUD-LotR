

using Dominio.ENUMS;
using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using static Dominio.Servicos.ServicoPersonagem;

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
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.IsType<List<Personagem>>(listaDePersonagens);
        }

        [Fact]
        public void DeveRetornarUmaListaDeTamanhoIgualADaListaDeclaradaNoTeste()
        {
            //arranje
            List<Personagem> personagens = new List<Personagem>()
            {
                new (1, "Aragorn", 1, ProfissaoEnum.Guerreiro),
                new (2, "Legolas", 2, ProfissaoEnum.Arqueiro),
                new (3, "Guimli", 3, ProfissaoEnum.Guerreiro),
                new (3, "Gandalf", 4, ProfissaoEnum.Mago)
            };
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.Equal(personagens.Count, listaDePersonagens.Count);
        }

        [Fact]
        public void DeveRetornarUmaListaIgualAListaDeclaradaNoTeste()
        {
            //arranje
            List<Personagem> personagens = new List<Personagem>()
            {
                new (1, "Aragorn", 1, ProfissaoEnum.Guerreiro),
                new (2, "Legolas", 2, ProfissaoEnum.Arqueiro),
                new (3, "Guimli", 3, ProfissaoEnum.Guerreiro),
                new (3, "Gandalf", 4, ProfissaoEnum.Mago)
            };
            //act
            var listaDePersonagens = servicoPersonagem.ObterTodos();
            //assert
            Assert.Equivalent(personagens.SequenceEqual(listaDePersonagens, new CompararListaDePersonagens()));
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
