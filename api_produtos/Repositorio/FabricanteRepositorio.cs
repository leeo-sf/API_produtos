using api_produtos.Data;
using api_produtos.Models;
using api_produtos.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_produtos.Repositorio
{
    public class FabricanteRepositorio : IFabricante
    {
        private readonly DBContext _context;

        public FabricanteRepositorio(DBContext context)
        {
            _context = context;
        }

        public async Task<Fabricante> BuscarPorId(int id)
        {
            return await _context.Fabricante.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> FabricanteExiste(int id)
        {
            var existe = await _context.Fabricante.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Fabricante>> BuscarTodosFabricantes()
        {
            return await _context.Fabricante.ToListAsync();
        }

        public async Task CadastrarFabricante(Fabricante fabricante)
        {
            _context.Fabricante.Add(fabricante);
            await _context.SaveChangesAsync();
        }

        public async Task EditarFabricante(int id, Fabricante fabricante)
        {
            var existe = await _context.Fabricante.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                throw new Exception($"ID {id} não encontrado no banco de dados.");
            }

            try
            {
                _context.Fabricante.Update(fabricante);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletarFabricante(int id)
        {
            try
            {
                var obj = await BuscarPorId(id);
                _context.Fabricante.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
