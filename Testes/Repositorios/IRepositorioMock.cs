using Dominio;
using System;
using System.Collections.Generic;

namespace Testes.Repositorios
{
    public interface IRepositorioMock<T>
    {
        List<T> ObterTodos();

    }
}
