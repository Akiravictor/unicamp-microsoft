using OngConnection.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Models
{
    [Table("SOCIAL_WORKER")]
    public class SocialWorker : Entity<SocialWorker, Guid>
    {
        public string? Nome { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}
