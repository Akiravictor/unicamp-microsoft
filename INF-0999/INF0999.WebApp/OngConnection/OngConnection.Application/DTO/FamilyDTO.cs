using OngConnection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Application.DTO
{
	public class FamilyDTO
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string CEP { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public int Membros { get; set; }
		public ContactType Atendida { get; set; }
		public string Observacoes { get; set; }

		public int ErrorCount { get; set; }
		public string ErrorMessage { get; set; }
	}
}
