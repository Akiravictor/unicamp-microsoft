using OngConnection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Repositories
{
    public interface ISocialWorkerRepository
    {
		Task<bool> AddSocialWorker(SocialWorker socialWorker);
		IEnumerable<SocialWorker> GetSocialWorkers();
		SocialWorker? GetSocialWorkerByEmail(string email);
		bool UpdateSocialWorker(SocialWorker socialWorker);
		bool RemoveSocialWorker(SocialWorker socialWorker);

	}
}
