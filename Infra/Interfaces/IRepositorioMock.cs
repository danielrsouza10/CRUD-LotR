using Dominio;
using System;
using System.Collections.Generic;
using Dominio.Modelos;

namespace Testes.Interfaces
{
    public interface IRepositorioMock<T>
    {
        List<T> CriarListaSingleton();
        List<T> ObterTodos();
        Personagem ObterPorId(int id);
        Personagem Criar();
        Personagem Editar();
        void Deletar();
    }
}
