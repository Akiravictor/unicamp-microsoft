using OngConnection.Domain.Enums;
using OngConnection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Interfaces
{
    public interface IFamilyServices
    {
		Task<bool> RegisterNewFamily(Family family);
		Family? GetFamily(string id);
		List<Family> GetFamilies();
		List<Family> GetFamilies(ContactType contact);
		bool UpdateFamily(Family family);
		bool RemoveFamily(Family family);

	}
}
