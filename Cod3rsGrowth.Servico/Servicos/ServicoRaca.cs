
using Dominio.Filtros;
using Dominio.Modelos;
using Dominio.Validacao;
using FluentValidation;
using LinqToDB.SqlQuery;
using Testes.Interfaces;
namespace Servico.Servicos
{
    public class ServicoRaca
    {
        private readonly IRepositorio<Raca> _servicoRepositorio;
        private readonly RacaValidacao _racaValidacao;

        public ServicoRaca(IRepositorio<Raca> servicoRepositorio, RacaValidacao racaValidacao)
        {
            _servicoRepositorio = servicoRepositorio;
            _racaValidacao = racaValidacao;
        }

        public IEnumerable<Raca> ObterTodos(Filtro filtro) => _servicoRepositorio.ObterTodos(filtro);
        public Raca ObterPorId(int id) => id < 0 ? throw new ArgumentOutOfRangeException("O ID deve ser maior que zero") : _servicoRepositorio.ObterPorId(id);
        public void Deletar(int id) => _servicoRepositorio.Deletar(id);
        public int Criar(Raca raca)
        {
            var resultadoValidacao = _racaValidacao
                .Validate(raca, options => options.IncludeRuleSets("Criacao"));
            if (!resultadoValidacao.IsValid)
            {
                throw new ValidationException(resultadoValidacao.Errors);
            }
            return _servicoRepositorio.Criar(raca);
        }
        public Raca Editar(Raca raca)
        {
            var resultadoValidacao = _racaValidacao
                .Validate(raca, options => options.IncludeRuleSets("Edicao"));
            if (!resultadoValidacao.IsValid)
            {
                throw new ValidationException(resultadoValidacao.Errors);
            }
            return _servicoRepositorio.Editar(raca);
        }
    }
}

