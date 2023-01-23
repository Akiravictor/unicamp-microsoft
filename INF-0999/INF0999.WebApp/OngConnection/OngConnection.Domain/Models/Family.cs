using OngConnection.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Models
{
    [Table("FAMILIES")]
    public class Family : Entity<Family, Guid>
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Membros { get; set; }
        public int Atendida { get; set; }
        public string Observacoes { get; set; }
    }
}
