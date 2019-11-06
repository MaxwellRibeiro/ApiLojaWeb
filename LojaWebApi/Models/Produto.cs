using Dapper.Contrib.Extensions;

namespace LojaWebApi.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlFoto { get; set; }
        public string NomeLoja { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}