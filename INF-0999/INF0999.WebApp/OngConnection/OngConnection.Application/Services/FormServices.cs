using Microsoft.Extensions.Logging;
using OngConnection.Application.DTO;
using OngConnection.Application.Interfaces;
using OngConnection.Domain.Enums;
using OngConnection.Domain.Interfaces;
using OngConnection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OngConnection.Application.Services
{
	public class FormServices : IFormServices
	{
		private readonly ILogger<FormServices> _logger;
		private readonly IFamilyServices _familyServices;

		public FormServices(ILogger<FormServices> logger, IFamilyServices familyServices)
		{
			_logger = logger;
			_familyServices = familyServices;
		}

		public async Task<bool> RegisterFamily(FamilyDTO dto)
		{
			var family = new Family
			{
				Nome = dto.Nome,
				Telefone = dto.Telefone,
				Email = dto.Email,
				Endereco = dto.Endereco,
				CEP = dto.CEP,
				Cidade = dto.Cidade,
				Estado = dto.Estado,
				Membros = dto.Membros,
				Observacoes = dto.Observacoes,
				Atendida = (int)ContactType.NaoAtendido
			};
 
			var result = await _familyServices.RegisterNewFamily(family);

			return result;
		}

		public FamilyDTO GetFamilyDetails(string id)
		{
			var family = _familyServices.GetFamily(id);
			var familyDto = new FamilyDTO();

			if(family != null)
			{
				familyDto.Nome = family.Nome;
				familyDto.Telefone = family.Telefone;
				familyDto.Email = family.Email;
				familyDto.Endereco = family.Endereco;
				familyDto.CEP = family.CEP;
				familyDto.Cidade = family.Cidade;
				familyDto.Estado = family.Estado;
				familyDto.Membros = family.Membros;
				familyDto.Observacoes = family.Observacoes;
				familyDto.Atendida = (ContactType)family.Atendida;
			}
			else
			{
				familyDto.ErrorCount += 1;
				familyDto.ErrorMessage = "Não foi encontrada uma família com o Nome especificado.";
			}
			
			return familyDto;
		}

		public List<FamilyDTO> GetAllFamilies()
		{
			var families = _familyServices.GetFamilies();
			var dtos = new List<FamilyDTO>();

			foreach (var family in families)
			{
				dtos.Add(new FamilyDTO
				{
					Nome = family.Nome,
					Endereco = family.Endereco,
					CEP = family.CEP,
					Cidade = family.Cidade,
					Estado = family.Estado,
					Telefone = family.Telefone,
					Email = family.Email,
					Membros = family.Membros,
					Atendida = (ContactType)family.Atendida,
					Observacoes = family.Observacoes
				});
			}

			return dtos;
		}

		public bool UpdateFamilyDetails(FamilyDTO dto)
		{
			var family = new Family
			{
				Nome = dto.Nome,
				Telefone = dto.Telefone,
				Email = dto.Email,
				Endereco = dto.Endereco,
				CEP = dto.CEP,
				Cidade = dto.Cidade,
				Estado = dto.Estado,
				Membros = dto.Membros,
				Observacoes = dto.Observacoes,
				Atendida = (int)dto.Atendida
			};

			var result = _familyServices.UpdateFamily(family);

			return result;
		}

		public bool RemoveFamily(FamilyDTO dto)
		{
			var family = new Family
			{
				Nome = dto.Nome,
				Telefone = dto.Telefone,
				Email = dto.Email,
				Endereco = dto.Endereco,
				CEP = dto.CEP,
				Cidade = dto.Cidade,
				Estado = dto.Estado,
				Membros = dto.Membros,
				Observacoes = dto.Observacoes,
				Atendida = (int)dto.Atendida
			};

			var result = _familyServices.RemoveFamily(family);

			return result;
		}
	}
}
