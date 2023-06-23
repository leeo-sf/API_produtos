using api_produtos.Models;

namespace api_produtos.Repositorio.Interface
{
    public interface IFabricante
    {
        Task<Fabricante> BuscarPorId(int id);
        Task<Boolean> FabricanteExiste(int id);
    }
}
