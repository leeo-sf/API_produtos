using api_produtos.Models;

namespace api_produtos.Repositorio.Interface
{
    public interface ICategoria
    {
        Task<Categoria> BuscarPorId(int id);
        Task<Boolean> CategoriaExiste(int id);
    }
}
