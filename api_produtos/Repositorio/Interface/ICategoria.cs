using api_produtos.Models;

namespace api_produtos.Repositorio.Interface
{
    public interface ICategoria
    {
        Task<Categoria> BuscarPorId(int id);
        Task<Boolean> CategoriaExiste(int id);
        Task<List<Categoria>> ListarTodasCategorias();
        Task CadastrarCategoria(Categoria categoria);
        Task AlterarCategoria(int id, Categoria categoria);
        Task ApagarCategoria(int id);
    }
}
