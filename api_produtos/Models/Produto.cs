using System.ComponentModel.DataAnnotations.Schema;

namespace api_produtos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column("id_fabricante")]
        public int IdFabricante { get; set; }
        [Column("id_categoria")]
        public int IdCategoria { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }

        public Fabricante Fabricante { get; set; }
        public Categoria Categoria { get; set; }

        public Produto(int id, string nome, int idFabricante, int idCategoria, float preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            IdFabricante = idFabricante;
            IdCategoria = idCategoria;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}
