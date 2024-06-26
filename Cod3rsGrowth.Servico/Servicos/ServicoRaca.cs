
using Dominio.Filtros;
using Dominio.Modelos;
using Dominio.Validacao;
using FluentValidation;
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
        public Raca ObterPorId(int id) => id < 0 ? throw new Exception("O ID deve ser maior que zero") : _servicoRepositorio.ObterPorId(id);
        public void Deletar(int id) => _servicoRepositorio.Deletar(id);
        public void Criar(Raca raca)
        {
            var resultadoValidacao = _racaValidacao
                .Validate(raca, options => options.IncludeRuleSets("Criacao"));
            if (!resultadoValidacao.IsValid)
            {
                var erros = "";
                const string SerapacaoEntreErros = ".\n";
                foreach (var falha in resultadoValidacao.Errors)
                {
                    //erros += falha.ErrorMessage + SerapacaoEntreErros;
                    throw new Exception(falha.ErrorMessage);
                }
            }
            _servicoRepositorio.Criar(raca);
        }
        public Raca Editar(Raca raca)
        {
            var resultadoValidacao = _racaValidacao
                .Validate(raca, options => options.IncludeRuleSets("Edicao"));
            if (!resultadoValidacao.IsValid)
            {
                var erros = "";
                const string SerapacaoEntreErros = ".\n";
                foreach (var falha in resultadoValidacao.Errors)
                {
                    //erros += falha.ErrorMessage + SerapacaoEntreErros;
                    throw new Exception(falha.ErrorMessage);
                }
            }
            return _servicoRepositorio.Editar(raca);
        }
    }
}

