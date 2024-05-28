using Dominio.Modelos;


namespace Dominio.Interfaces
{
    public interface IServicoPersonagem
    {
        void Criar(Personagem personagem);
        Personagem Editar(Personagem personagem);
        void Deletar(int id);
        Personagem ObterPorId(int id);
        List<Personagem> ObterTodos();
    }
}
