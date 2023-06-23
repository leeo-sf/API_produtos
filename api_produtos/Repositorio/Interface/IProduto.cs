using api_produtos.Models;

namespace api_produtos.Repositorio.Interface
{
    public interface IProduto
    {
        Task<List<Produto>> BuscarTodosProdutos();
        Task<Produto> BuscarPorId(int id);
        Task CadastrarNovoProduto(Produto produto);
        Task EditarProduto(int id, Produto produto);
    }
}
