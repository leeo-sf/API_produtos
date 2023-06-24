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

        public async Task<List<Categoria>> ListarTodasCategorias()
        {
            return await _context.Categoria.ToListAsync();
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

        public async Task CadastrarCategoria(Categoria categ)
        {
            _context.Add(categ);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarCategoria(int id, Categoria categoria)
        {
            var existe = await _context.Categoria.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                throw new Exception($"ID {id} não encontrado no banco de dados.");
            }

            try
            {
                _context.Categoria.Update(categoria);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task ApagarCategoria(int id)
        {
            try
            {
                var obj = await BuscarPorId(id);
                _context.Categoria.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
