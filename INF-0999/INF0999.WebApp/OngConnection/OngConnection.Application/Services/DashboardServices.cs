using Microsoft.Extensions.Logging;
using OngConnection.Application.DTO;
using OngConnection.Application.Interfaces;
using OngConnection.Domain.Enums;
using OngConnection.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Application.Services
{
	public class DashboardServices : IDashboardServices
	{
		private readonly ILogger<DashboardServices> _logger;
		private readonly IFamilyServices _familyServices;

		public DashboardServices(ILogger<DashboardServices> logger, IFamilyServices familyServices)
		{
			_logger = logger;
			_familyServices = familyServices;
		}

		public List<FamilyDTO> GetAllFamilies()
		{
			var families = _familyServices.GetFamilies();
			var dtos = new List<FamilyDTO>();

			foreach(var family in families)
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

		public bool MoveFamily(string id, ContactType changeTo)
		{
			var family = _familyServices.GetFamily(id);

			if (family != null)
			{
				family.Atendida = (int)changeTo;

				var result = _familyServices.UpdateFamily(family);

				return result;
			}

			return false;
		}
	}
}
