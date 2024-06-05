
using Dominio.Modelos;
using Dominio.Validacao;
using FluentValidation;
using Testes.Interfaces;
namespace Servico.Servicos
{
    public class ServicoPersonagem
    {
        private readonly IRepositorio<Personagem> _servicoRepositorio;
        private readonly PersonagemValidacao _personagemValidacao;

        public ServicoPersonagem(IRepositorio<Personagem> servicoRepositorio, PersonagemValidacao personagemValidacao)
        {
            _servicoRepositorio = servicoRepositorio;
            _personagemValidacao = personagemValidacao;
        }
        public List<Personagem> ObterTodos(string propriedade) => _servicoRepositorio.ObterTodos(propriedade);
        public void Deletar(int id) => _servicoRepositorio.Deletar(id);
        public Personagem ObterPorId(int id)
        {
            if (id < 0) throw new Exception("O ID tem que ser maior que zero");
            return _servicoRepositorio.ObterPorId(id);
        }
        public void Criar(Personagem personagem)
        {

            var resultadoValidacao = _personagemValidacao
                .Validate(personagem, options => options.IncludeRuleSets("Criacao"));
            if (!resultadoValidacao.IsValid)
            {
                var erros = "";
                const string SerapacaoEntreErros = ". ";
                foreach (var falha in resultadoValidacao.Errors)
                {
                    erros += falha.ErrorMessage + SerapacaoEntreErros;
                }
                throw new Exception(erros);
            }
            _servicoRepositorio.Criar(personagem);
        }
        public Personagem Editar(Personagem personagem)
        {
            var resultadoValidacao = _personagemValidacao
                .Validate(personagem, options => options.IncludeRuleSets("Edicao"));
            if (!resultadoValidacao.IsValid)
            {
                var erros = "";
                foreach (var falha in resultadoValidacao.Errors)
                {
                    erros += falha.ErrorMessage + ". ";
                }
                throw new Exception(erros);
            }
            return _servicoRepositorio.Editar(personagem);
        }
    }
}
