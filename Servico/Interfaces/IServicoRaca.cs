using Dominio.Modelos;


namespace Dominio.Interfaces
{
    public interface IServicoRaca
    {
        void Criar(Raca raca);
        Raca Editar(Raca raca);
        void Deletar(int id);
        Raca ObterPorId(int id);
        List<Raca> ObterTodos();
    }
}
