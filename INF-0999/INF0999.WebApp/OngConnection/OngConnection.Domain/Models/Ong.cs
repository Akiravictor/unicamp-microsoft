using OngConnection.Domain.Base;
using OngConnection.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngConnection.Domain.Models
{
    [Table("ONGS")]
    public class Ong : Entity<Ong, Guid>
    {
        public string? NomeOng { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public OngType Tipo { get; set; }
    }
}
