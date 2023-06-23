namespace api_produtos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Categoria(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
