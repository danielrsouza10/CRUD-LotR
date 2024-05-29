using Dominio.Modelos;
using System;
using Testes.Interfaces;
using Testes.Singleton;

namespace Testes.Repositorios
{
    public class RepositorioMockRacas : IRepositorio<Raca>
    {

        private List<Raca> _listaDeRacas = RacaSingleton.Instance.Racas;

        public List<Raca> ObterTodos()
        {
            return _listaDeRacas;
        }

        public Raca ObterPorId(int id) => _listaDeRacas.Find(r => r.Id == id) ?? throw new Exception("O ID informado não existe");

        public void Criar(Raca raca)
        {
            const int IncrementoParaONovoId = 1;
            raca.Id = _listaDeRacas.Any() ? _listaDeRacas.Max(r => r.Id) + IncrementoParaONovoId : IncrementoParaONovoId;
            _listaDeRacas.Add(raca);
        }

        public Raca Editar(Raca raca)
        {
            var racaExistente = ObterPorId(raca.Id);
            if (raca.Nome != null) racaExistente.Nome = raca.Nome;
            racaExistente.HabilidadeRacial = raca.HabilidadeRacial;
            racaExistente.LocalizacaoGeografica = raca.LocalizacaoGeografica;
            return racaExistente;
        }

        public void Deletar(int id) => _listaDeRacas.Remove(ObterPorId(id));
    }
}