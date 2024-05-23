
using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validacao;
using FluentValidation;
using Testes.Interfaces;
namespace Dominio.Servicos
{
    public class ServicoPersonagem : IServicoPersonagem
    {
        private readonly IRepositorioMock<Personagem> _servicoRepositorio;
        private readonly PersonagemValidacao _personagemValidacao;

        public ServicoPersonagem(IRepositorioMock<Personagem> servicoRepositorio, PersonagemValidacao personagemValidacao)
        {
            _servicoRepositorio = servicoRepositorio;
            _personagemValidacao = personagemValidacao;
            
        }
        public void Criar(Personagem personagem)
        {
            var resultadoValidacao = _personagemValidacao.Validate(personagem);
            if (!resultadoValidacao.IsValid)
            {
                foreach (var falha in resultadoValidacao.Errors)
                {
                    throw new Exception("Property " + falha.PropertyName + " failed validation. Error was: " + falha.ErrorMessage);
                }
                
            }
            _servicoRepositorio.Criar(personagem);
        }
        public void Deletar()
        {
            throw new NotImplementedException();
        }
        public Personagem Editar()
        {
            throw new NotImplementedException();
        }
        public Personagem ObterPorId(int id)
        {
            if (id < 0)
            {
                throw new Exception("O ID tem que ser maior que zero");
            }
            return _servicoRepositorio.ObterPorId(id);
        }
        public List<Personagem> ObterTodos()
        {
            return _servicoRepositorio.ObterTodos();
        }

        
    }
}
