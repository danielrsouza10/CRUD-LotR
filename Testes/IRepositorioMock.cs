using Dominio;
using System;
using System.Collections.Generic;

public interface IRepositorioMock<T>
{
    List<T> ObterTodos();
  
}