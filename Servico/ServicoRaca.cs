using Dominio.Interfaces;
using Dominio.Modelos;
using System.Collections.Generic;
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
        public Raca ObterPorId(int id) => id > 0 ? _servicoRepositorio.ObterPorId(id) : throw new Exception("O ID deve ser maior que zero");


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

       
    }
}

