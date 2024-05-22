using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IServicoPersonagem
    {
        Personagem Criar();
        Personagem Editar();
        void Deletar();
        Personagem ObterPorId(int id);
        List<Personagem> ObterTodos();
    }
}
