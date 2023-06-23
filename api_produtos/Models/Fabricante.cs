namespace api_produtos.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Fabricante(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
