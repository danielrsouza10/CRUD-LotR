using Dominio;
using System;
using System.Collections.Generic;
using Dominio.Modelos;

namespace Testes.Interfaces
{
    public interface IRepositorioMock<T>
    {
        List<T> ObterTodos();
        T ObterPorId(int id);
        void Criar(T t);
        T Editar(T t);
        void Deletar(int id);
    }
}
