using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaWebApi.Models
{
    [Table("login")]
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeLoja { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}