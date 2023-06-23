using api_produtos.Data;
using api_produtos.Models;
using api_produtos.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_produtos.Repositorio
{
    public class CategoriaRepositorio : ICategoria
    {
        private readonly DBContext _context;

        public CategoriaRepositorio(DBContext context)
        {
            _context = context;
        }

        public async Task<Categoria> BuscarPorId(int id)
        {
            return await _context.Categoria.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CategoriaExiste(int id)
        {
            var existe = await _context.Categoria.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return false;
            }

            return true;
        }
    }
}
