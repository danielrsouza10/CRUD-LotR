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
                .NotNull().WithMessage("O nome do personagem não pode ser null")
                .NotEmpty().WithMessage("Precisa informar um nome para o personagem")
                .Length(3, 25).WithMessage("O nome do personagem precisa ter entre 3 e 25 caracteres");
            RuleFor(personagem => personagem.Id)
                .Empty().WithMessage("Não deve ser informado um Id");
            RuleFor(personagem => personagem.IdRaca)
                .NotNull().WithMessage("O Id da raça não pode ser null")
                .NotEmpty().WithMessage("Deve ser informado um id correspondente a raça do personagem");
            RuleFor(personagem => personagem.EstaVivo)
                .NotNull().WithMessage("É necessário informar se o personagem está vivo ou não");
            RuleFor(Personagem => Personagem.Profissao)
                .NotNull().WithMessage("É necessário selecionar uma classe")
                .IsInEnum().WithMessage("É necessário selecionar uma classe");
        });
        RuleSet("Edicao", () => 
        {
            RuleFor(personagem => personagem.Nome)
                .Length(3, 25).WithMessage("O nome do personagem precisa ter entre 3 e 25 caracteres");
        });
        
    }
}