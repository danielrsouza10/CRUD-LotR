﻿using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IServicoPersonagem
    {
        List<Personagem> ObterTodos();
        Personagem ObterPorId(int id);
        Personagem Criar();
        Personagem Editar();
        Personagem Deletar();
    }
}
