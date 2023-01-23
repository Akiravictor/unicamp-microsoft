using Microsoft.Extensions.Logging;
using OngConnection.Domain.Enums;
using OngConnection.Domain.Interfaces;
using OngConnection.Domain.Models;
using OngConnection.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Services
{
    public class FamilyServices : IFamilyServices
    {
        private readonly ILogger<FamilyServices> _logger;
        private readonly IFamilyRepository _familyRepository;

        public FamilyServices(ILogger<FamilyServices> logger, IFamilyRepository familyRepository)
        {
            _logger = logger;
            _familyRepository = familyRepository;
        }

        public async Task<bool> RegisterNewFamily(Family family)
        {
            var result = await _familyRepository.AddFamily(family);

            return result;
        }

        public Family? GetFamily(string id)
        {
            return _familyRepository.GetFamily(id);
        }

        public List<Family> GetFamilies()
        {
            return _familyRepository.GetAllFamilies().ToList();
        }

        public List<Family> GetFamilies(ContactType contact)
        {
            return _familyRepository.GetByExpression(f => f.Atendida == (int)contact).ToList();
        }

        public bool UpdateFamily(Family family)
        {
            return _familyRepository.UpdateFamily(family);
        }

        public bool RemoveFamily(Family family)
        {
            return _familyRepository.RemoveFamily(family);
        }
    }
}
