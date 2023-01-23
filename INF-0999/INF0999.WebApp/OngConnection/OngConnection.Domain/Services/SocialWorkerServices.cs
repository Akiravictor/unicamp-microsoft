using Microsoft.Extensions.Logging;
using OngConnection.Domain.Interfaces;
using OngConnection.Domain.Models;
using OngConnection.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Services
{
	public class SocialWorkerServices : ISocialWorkerServices
	{
		private readonly ILogger<SocialWorkerServices> _logger;
		private readonly ISocialWorkerRepository _socialWorkerRepository;

		public SocialWorkerServices(ILogger<SocialWorkerServices> logger, ISocialWorkerRepository socialWorkerRepository)
		{
			_logger = logger;
			_socialWorkerRepository = socialWorkerRepository;
		}

		public async Task<bool> CreateNewSocialWorker(string nome, string email)
		{
			var socialWorker = new SocialWorker
			{
				Nome = nome,
				Email = email,
				Endereco = string.Empty,
				Cidade = string.Empty,
				Estado = string.Empty,
				CEP = string.Empty,
				Telefone = string.Empty				
			};

			var result = await _socialWorkerRepository.AddSocialWorker(socialWorker);

			return result;
		}

		public SocialWorker? GetSocialWorker(string email)
		{
			return _socialWorkerRepository.GetSocialWorkerByEmail(email);
		}

		public bool RemoveSocialWorker(string email)
		{
			var obj = _socialWorkerRepository.GetSocialWorkerByEmail(email);

			if(obj != null)
			{
				var result = _socialWorkerRepository.RemoveSocialWorker(obj);

				return result;
			}

			return false;
		}

		public bool UpdateSocialWorker(SocialWorker socialWorker)
		{
			var result = _socialWorkerRepository.UpdateSocialWorker(socialWorker);

			return result;
		}
	}
}
