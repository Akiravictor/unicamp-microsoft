using OngConnection.Application.DTO;
using OngConnection.Domain.Models;
using OngConnection.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Utilities.Mapping
{
	public static class Map
	{
		public static FamilyDTO VMtoDTO(FamilyViewModel vm)
		{
			return new FamilyDTO
			{
				Id = vm.Id,
				Nome = vm.Nome ?? "",
				Email = vm.Email ?? "",
				Telefone = vm.Telefone ?? "",
				Endereco = vm.Endereco ?? "",
				CEP = vm.CEP ?? "",
				Cidade = vm.Cidade ?? "",
				Estado = vm.Estado ?? "",
				Membros = vm.Membros,
				Observacoes = vm.Observacoes ?? "",
				Atendida = vm.Atendida
			};
		}

		

		public static Family DTOtoDomain(FamilyDTO dto)
		{
			return new Family
			{
				Id = dto.Id,
				Nome = dto.Nome,
				Email = dto.Email,
				Telefone = dto.Telefone,
				Endereco = dto.Endereco,
				CEP = dto.CEP,
				Cidade = dto.Cidade,
				Estado = dto.Estado,
				Membros = dto.Membros,
				Observacoes = dto.Observacoes,
				Atendida = (int)dto.Atendida
			};
		}

		public static Ong DTOtoDomain(OngDTO dto)
		{
			return new Ong
			{
				Id = dto.Id,
				NomeOng = dto.NomeOng,
				Email = dto.Email,
				Telefone = dto.Telefone,
				Endereco = dto.Endereco,
				CEP = dto.CEP,
				Cidade = dto.Cidade,
				Estado = dto.Estado,
				Tipo = dto.Tipo
			};
		}

		public static SocialWorker DTOtoDomain(SocialWorkerDTO dto)
		{
			return new SocialWorker
			{
				Id = dto.Id,
				Nome = dto.Nome,
				Email = dto.Email,
				Telefone = dto.Telefone,
				Endereco= dto.Endereco,
				CEP = dto.CEP,
				Cidade = dto.Cidade,
				Estado = dto.Estado
			};
		}

		
	}
}
