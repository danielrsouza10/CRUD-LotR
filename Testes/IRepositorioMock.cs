using Dominio;
using System;
using System.Collections.Generic;

public interface IRepositorioMock
{
    List<Personagem> ObterTodosOsPersonagens();
    List<Raca> ObterTodasAsRacas();
}
