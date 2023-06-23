using api_produtos.Data;
using api_produtos.Models;
using api_produtos.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_produtos.Repositorio
{
    public class ProdutoRepositorio : IProduto
    {
        private readonly DBContext _context;

        public ProdutoRepositorio(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Produto> BuscarPorId(int id)
        {
            return await _context.Produto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CadastrarNovoProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task EditarProduto(int id, Produto produto)
        {
            var existe = await _context.Produto.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                throw new Exception($"ID {id} não encontrado no banco de dados.");
            }

            try
            {
                _context.Produto.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
