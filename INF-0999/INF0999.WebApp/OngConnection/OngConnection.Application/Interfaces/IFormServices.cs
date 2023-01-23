using OngConnection.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Application.Interfaces
{
	public interface IFormServices
	{
		Task<bool> RegisterFamily(FamilyDTO dto);
		FamilyDTO GetFamilyDetails(string id);
		List<FamilyDTO> GetAllFamilies();
		bool UpdateFamilyDetails(FamilyDTO dto);
		bool RemoveFamily(FamilyDTO dto);
	}
}
