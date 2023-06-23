using api_produtos.Data;
using api_produtos.Repositorio;
using api_produtos.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_produtos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DBContext>(
                options => options.UseMySql(builder.Configuration.GetConnectionString("DataBase"), new MySqlServerVersion(new Version(8, 0, 30))));

            //config injeção de dependência {toda vez que a interface for chamada a classe que será instanciada é UsuarioRepositorio}
            builder.Services.AddScoped<IProduto, ProdutoRepositorio>();
            builder.Services.AddScoped<IFabricante, FabricanteRepositorio>();
            builder.Services.AddScoped<ICategoria, CategoriaRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}