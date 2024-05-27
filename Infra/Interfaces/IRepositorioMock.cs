using Dominio;
using System;
using System.Collections.Generic;
using Dominio.Modelos;

namespace Testes.Interfaces
{
    public interface IRepositorioMock<T>
    {
        List<T> ObterTodos();
        Personagem ObterPorId(int id);
        void Criar(Personagem personagem);
        Personagem Editar(Personagem personagem);
        void Deletar(Personagem personagem);
    }
}
