using OngConnection.Application.DTO;
using OngConnection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Application.Interfaces
{
	public interface IDashboardServices
	{
		List<FamilyDTO> GetAllFamilies();
		bool MoveFamily(string id, ContactType changeTo);
	}
}
