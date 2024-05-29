using Dominio.Modelos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Validacao;

    public class RacaValidacao : AbstractValidator<Raca>
    {
        public RacaValidacao()
        {
            RuleSet("Criacao", () =>
            { 
                RuleFor(raca => raca.Nome)
                    .NotNull().WithMessage("O nome da raça não pode ser null")
                    .NotEmpty().WithMessage("Precisa informar um nome para a raça")
                    .Length(3, 25).WithMessage("O nome da raça precisa ter entre 3 e 25 caracteres");
                RuleFor(raca => raca.Id).Empty().WithMessage("Não deve ser informado um Id");
            });
            RuleSet("Edicao", () =>
            {
                RuleFor(raca => raca.Nome)
                    .Length(3, 25).WithMessage("O nome da raça precisa ter entre 3 e 25 caracteres");
            });
        }
    }

