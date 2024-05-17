using Dominio.Interfaces;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoPersonagem : IServicoPersonagem
    {
        List<Personagem> ListaDePersonagens = new List<Personagem>();
        public List<Personagem> ObterTodos()
        {
            return ListaDePersonagens;
        }
    }
}
