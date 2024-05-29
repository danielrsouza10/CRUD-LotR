using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validacao;

public class PersonagemValidacao : AbstractValidator<Personagem>
{
    public PersonagemValidacao()
    {
        RuleSet("Criacao", () =>
        {
            RuleFor(personagem => personagem.Nome)
                .NotNull().WithMessage("O nome do persongam não pode ser null")
                .NotEmpty().WithMessage("Precisa informar um nome para o personagem")
                .Length(3, 25).WithMessage("O nome do personagem precisa ter entre 3 e 25 caracteres");
            RuleFor(personagem => personagem.Id)
                .Empty().WithMessage("Não deve ser informado um Id");
        });
        RuleSet("Edicao", () => 
        {
            RuleFor(personagem => personagem.Nome)
                .Length(3, 25).WithMessage("O nome do personagem precisa ter entre 3 e 25 caracteres");
        });
        
    }
}