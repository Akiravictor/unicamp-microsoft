using OngConnection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Interfaces
{
	public interface ISocialWorkerServices
	{
		Task<bool> CreateNewSocialWorker(string nome, string email);
		SocialWorker? GetSocialWorker(string email);
		bool UpdateSocialWorker(SocialWorker socialWorker);
		bool RemoveSocialWorker(string email);
	}
}
