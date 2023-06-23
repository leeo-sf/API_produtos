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
    }
}
