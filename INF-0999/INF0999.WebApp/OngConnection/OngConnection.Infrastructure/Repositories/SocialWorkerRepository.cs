using Microsoft.EntityFrameworkCore;
using OngConnection.Domain.Models;
using OngConnection.Domain.Repositories;
using OngConnection.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Infrastructure.Repositories
{
    public class SocialWorkerRepository : Repository<SocialWorker, Guid>, ISocialWorkerRepository
    {
        public SocialWorkerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> AddSocialWorker(SocialWorker socialWorker)
        {
            await AddAsync(socialWorker);
            var result = SaveChanges();

            return result > 0;
        }

        public IEnumerable<SocialWorker> GetSocialWorkers()
        {
            return GetAll();
        }

        public SocialWorker? GetSocialWorkerByEmail(string email)
        {
            return Find(m => m.Email == email).FirstOrDefault();
        }

        public bool UpdateSocialWorker(SocialWorker socialWorker)
        {
            var obj = Find(m => m.Email == socialWorker.Email).First();

            socialWorker.Id = obj.Id;

            Update(socialWorker);
            var result = SaveChanges();

            return result > 0;
        }

        public bool RemoveSocialWorker(SocialWorker socialWorker)
        {
            Delete(socialWorker);
            var result = SaveChanges();

            return result > 0;
        }
    }
}
