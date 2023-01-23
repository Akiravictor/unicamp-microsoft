using OngConnection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Repositories
{
    public interface IFamilyRepository
    {
        Task<bool> AddFamily(Family family);
        IEnumerable<Family> GetAllFamilies();
        Family? GetFamily(string id);
		IEnumerable<Family> GetByExpression(Expression<Func<Family, bool>> expression);
        bool UpdateFamily(Family family);
        bool RemoveFamily(Family family);
    }
}
