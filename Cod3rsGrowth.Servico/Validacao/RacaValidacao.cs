using Dominio.Modelos;
using FluentValidation;
using Testes.Interfaces;

namespace Dominio.Validacao;

    public class RacaValidacao : AbstractValidator<Raca>
    {
        private readonly IRepositorio<Raca> _repositorio;
        public RacaValidacao(IRepositorio<Raca> repositorio)
        {
            _repositorio = repositorio;
            RuleSet("Criacao", () =>
            {
                RuleFor(raca => raca.Id)
                    .Empty().WithMessage("Não deve ser informado um Id");
                RuleFor(raca => raca.Nome)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                        .NotNull().WithMessage("O nome da raça não pode ser null")
                        .NotEmpty().WithMessage("Precisa informar um nome para a raça")
                        .Length(3, 25).WithMessage("O nome da raça precisa ter entre 3 e 25 caracteres")
                        .Matches(@"^[a-zA-ZÀ-ÖØ-öø-ÿ'-]*$").WithMessage("O nome não pode conter caracteres especiais")
                        .Must(nome => !_repositorio.VerificarNomeNoDb(nome.ToLower(), null)).WithMessage("O nome da raça ja existe");
                RuleFor(raca => raca.EstaExtinta)
                    .NotNull().WithMessage("É necessário informar se a raça está exinta ou não");
            });
            RuleSet("Edicao", () =>
            {
                RuleFor(raca => raca.Nome)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                        .NotNull().WithMessage("O nome da raça não pode ser null")
                        .NotEmpty().WithMessage("Precisa informar um nome para a raça")
                        .Length(3, 25).WithMessage("O nome da raça precisa ter entre 3 e 25 caracteres")
                        .Matches(@"^[a-zA-ZÀ-ÖØ-öø-ÿ'-]*$").WithMessage("O nome não pode conter caracteres especiais")
                        .Must((personagem, nome) => !_repositorio.VerificarNomeNoDb(nome.ToLower(), personagem.Id)).WithMessage("O nome da raça ja existe");
            });
        }
    }

