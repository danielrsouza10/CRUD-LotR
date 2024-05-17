using Dominio;
using System;
using System.Collections.Generic;

namespace Testes.Interfaces
{
    public interface IRepositorioMock<T>
    {
        List<T> ObterTodos();

    }
}
