using api_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace api_produtos.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
    }
}
