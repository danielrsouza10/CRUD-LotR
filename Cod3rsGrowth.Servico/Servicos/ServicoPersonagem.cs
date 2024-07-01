
using Dominio.Filtros;
using Dominio.Modelos;
using Dominio.Validacao;
using FluentValidation;
using Servico.CustomExceptions;
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
        public IEnumerable<Personagem> ObterTodos(Filtro filtro) => _servicoRepositorio.ObterTodos(filtro);
        public void Deletar(int id) => _servicoRepositorio.Deletar(id);
        public Personagem ObterPorId(int id)
        {
            if (id < 0) throw new PersonagemCustomExceptions("api/personagem")
            {
                Detail = "O ID tem que ser maior que zero"
            };
            var personagem = _servicoRepositorio.ObterPorId(id);
            if (personagem == null)
                throw new PersonagemCustomExceptions("api/personagem")
                {
                    Detail = "Personagem não encontrado"
                };
            return _servicoRepositorio.ObterPorId(id);
        }
        public void Criar(Personagem personagem)
        {
            var resultadoValidacao = _personagemValidacao
                .Validate(personagem, options => options.IncludeRuleSets("Criacao"));
            if (!resultadoValidacao.IsValid)
            {
                string erros = string.Empty;
                foreach (var falha in resultadoValidacao.Errors)
                {
                    erros += falha.ErrorMessage;
                }
                throw new ValidationException(erros);
            }
            _servicoRepositorio.Criar(personagem);
        }
        public Personagem Editar(Personagem personagem)
        {
            var resultadoValidacao = _personagemValidacao
                .Validate(personagem, options => options.IncludeRuleSets("Edicao"));
            if (!resultadoValidacao.IsValid)
            {
                foreach (var falha in resultadoValidacao.Errors)
                {
                    throw new ValidationException(falha.ErrorMessage);
                }
            }
            return _servicoRepositorio.Editar(personagem);
        }
    }
}
