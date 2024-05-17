

using Dominio.Modelos;
using Testes.Singleton;

namespace Testes.TesteServicoPersonagem
{
    public class teste_servico_personagem : TesteBase
    {
        const int TAMANHO_ESPERADO_DA_LISTA = 4;
        [Fact]
        public void asdf()
        {
            var personagem = PersonagemSingleton.Instance;

            var a = personagem.Personagens;

            Assert.NotNull(a);
            Assert.Equal(TAMANHO_ESPERADO_DA_LISTA, a.Count);

        }


        [Fact]
        public void asd33f()
        {
            var personagem = PersonagemSingleton.Instance;
            var a = personagem.Personagens;
            a.Add(new Personagem());

            Assert.NotNull(a);
            Assert.Equal(TAMANHO_ESPERADO_DA_LISTA, a.Count);
        }
    }
}
