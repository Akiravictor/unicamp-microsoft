using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OngConnection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OngConnection.Web.Models
{
	public class FamilyViewModel
	{
		[ValidateNever]
		public Guid Id { get; set; }

		[Required]
		[Display(Name = "Nome")]
		public string? Nome { get; set; }

		[Required]
		[Display(Name = "Endereço")]
		public string? Endereco { get; set; }

		[Required]
		[Display(Name = "Cidade")]
		public string? Cidade { get; set; }
		
		[Display(Name = "CEP")]
		public string? CEP { get; set; }

		[Required]
		[Display(Name = "Estado")]
		public string? Estado { get; set; }

		[Display(Name = "Telefone")]
		public string? Telefone { get; set; }

		[Display(Name = "Email")]
		public string? Email { get; set; }

		[Display(Name = "Numero de Moradores")]
		public int Membros { get; set; }

		[Display(Name = "Status")]
		public ContactType Atendida { get; set; }

		[Display(Name = "Observações")]
		public string? Observacoes { get; set; }

		[ValidateNever]
		public bool IsError { get; set; } = false;
		[ValidateNever]
		public string Message { get; set; } = "";
	}
}
