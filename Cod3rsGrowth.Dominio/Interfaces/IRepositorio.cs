using Dominio;
using System;
using System.Collections.Generic;
using Dominio.Interfaces;
using Dominio.Filtros;

namespace Testes.Interfaces
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> ObterTodos(Filtro filtro);
        T ObterPorId(int id);
        void Criar(T t);
        T Editar(T t);
        void Deletar(int id);
    }
}