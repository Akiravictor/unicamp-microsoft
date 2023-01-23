using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OngConnection.Domain.Models;
using OngConnection.Domain.Repositories;
using OngConnection.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Infrastructure.Repositories
{
    public class FamilyRepository : Repository<Family, Guid>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> AddFamily(Family family)
        {
            var getFamily = GetByExpression(f => f.Nome.ToUpper() == family.Nome.ToUpper() 
                                                    && f.Endereco.ToUpper() == family.Endereco.ToUpper() 
                                                    && f.Cidade.ToUpper() == family.Cidade.ToUpper()
                                                    && f.Estado.ToUpper() == family.Estado.ToUpper());

            if(getFamily.Count() == 0)
            {
                await AddAsync(family);
                var result = SaveChanges();

                return result > 0;
            }

            return false;
        }

        public IEnumerable<Family> GetAllFamilies()
        {
            return GetAll();
        }

        public Family? GetFamily(string id)
        {
            return Find(f => f.Id.Equals(id))
                    .FirstOrDefault();
        }

        public IEnumerable<Family> GetByExpression(Expression<Func<Family, bool>> expression)
        {
            return Find(expression);
        }

        public bool UpdateFamily(Family family)
        {

            Update(family);
            var result = SaveChanges();

            return result > 0;
        }

        public bool RemoveFamily(Family family)
        {

			Delete(family);
            var result = SaveChanges();

            return result > 0;
        }
    }
}
