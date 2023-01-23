using Microsoft.EntityFrameworkCore;
using OngConnection.Domain.Models;
using OngConnection.Domain.Repositories;
using OngConnection.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Infrastructure.Repositories
{
    public class OngRepository : Repository<Ong, Guid>, IOngRepository
    {
        public OngRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> AddOng(Ong ong)
        {
            await AddAsync(ong);
            var result = SaveChanges();

            return result > 0;
        }

        public IEnumerable<Ong> GetAllOngs()
        {
            return GetAll();
        }

        public Ong? GetOngByEmail(string email)
        {
            return Find(m => m.Email == email).FirstOrDefault();
        }

        public bool UpdateOng(Ong ong)
        {
            var obj = Find(m => m.Email == ong.Email).First();

            ong.Id = obj.Id;

            Update(ong);
            var result = SaveChanges();

            return result > 0;
        }

        public bool RemoveOng(Ong ong)
        {
            Delete(ong);
            var result = SaveChanges();

            return result > 0;
        }
    }
}
