using Dapper.Contrib.Extensions;

namespace LojaWebApi.Models
{
    [Table("compra")]
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string NomeLoja { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal{ get; set; }
    }
}