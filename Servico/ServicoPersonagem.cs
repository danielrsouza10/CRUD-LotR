using System.Data.Common;
using Dominio.ENUMS;
using Dominio.Interfaces;
using Dominio.Modelos;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Testes.Interfaces;
using Testes.Singleton;

namespace Dominio.Servicos
{
    public class ServicoPersonagem : IServicoPersonagem
    {
        private readonly IRepositorioMock<Personagem> _servicoRepositorio;

        public ServicoPersonagem(IRepositorioMock<Personagem> servicoRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
        }
        public Personagem Criar()
        {
            throw new NotImplementedException();
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
