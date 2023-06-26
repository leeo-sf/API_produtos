using api_produtos.Models;

namespace api_produtos.Repositorio.Interface
{
    public interface IFabricante
    {
        Task<List<Fabricante>> BuscarTodosFabricantes();
        Task<Fabricante> BuscarPorId(int id);
        Task<Boolean> FabricanteExiste(int id);
        Task CadastrarFabricante(Fabricante fabricante);
        Task EditarFabricante(int id, Fabricante fabricante);
        Task DeletarFabricante(int id);
    }
}
