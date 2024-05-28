﻿using Dominio.Modelos;
using System;
using Testes.Interfaces;
using Testes.Singleton;

namespace Testes.Repositorios
{
    public class RepositorioMockRacas : IRepositorioMock<Raca>
    {

        private List<Raca> _listaDeRacas = RacaSingleton.Instance.Racas;

        public List<Raca> ObterTodos()
        {
            return _listaDeRacas;
        }

        public Raca ObterPorId(int id) => _listaDeRacas.Find(r => r.Id == id) ?? throw new Exception("O ID informado não existe");

        public void Criar(Raca raca)
        {
            var incrementoPraONovoId = 1;
            raca.Id = _listaDeRacas.Any() ? _listaDeRacas.Max(r => r.Id) + incrementoPraONovoId : 1;
            _listaDeRacas.Add(raca);
        }

        public Raca Editar(Raca raca)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}