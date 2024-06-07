using Dominio;
using System;
using System.Collections.Generic;
using Dominio.Modelos;

namespace Testes.Interfaces
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> ObterTodos(string nome);
        T ObterPorId(int id);
        void Criar(T t);
        T Editar(T t);
        void Deletar(int id);
    }
}