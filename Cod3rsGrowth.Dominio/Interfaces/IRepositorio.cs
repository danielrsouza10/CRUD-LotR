using Dominio.Filtros;

namespace Testes.Interfaces
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> ObterTodos(Filtro filtro);
        T ObterPorId(int id);
        int Criar(T t);
        T Editar(T t);
        void Deletar(int id);
        bool VerificarNomeNoDb(string nome, int? id = null);
    }
}