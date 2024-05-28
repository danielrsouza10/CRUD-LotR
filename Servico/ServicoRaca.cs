using Dominio.Interfaces;
using Dominio.Modelos;
using Testes.Interfaces;

namespace Dominio.Servicos
{
    public class ServicoRaca : IServicoRaca
    {
        private readonly IRepositorioMock<Raca> _servicoRepositorio;
        //private readonly RacaValidacao _personagemValidacao;

        public ServicoRaca(IRepositorioMock<Raca> servicoRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
            //_racaValidacao = racaValidacao;
        }

        public List<Raca> ObterTodos() => _servicoRepositorio.ObterTodos();
        

        public void Criar(Raca raca)
        {
            throw new NotImplementedException();
        }

        public Raca Editar(Raca raca)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Raca ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

