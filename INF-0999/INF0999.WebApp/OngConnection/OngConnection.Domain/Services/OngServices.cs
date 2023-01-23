using Microsoft.Extensions.Logging;
using OngConnection.Domain.Enums;
using OngConnection.Domain.Interfaces;
using OngConnection.Domain.Models;
using OngConnection.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Services
{
    public class OngServices : IOngServices
    {
        private readonly ILogger<OngServices> _logger;
        private readonly IOngRepository _ongRepository;

        public OngServices(ILogger<OngServices> logger, IOngRepository ongRepository)
        {
            _logger = logger;
            _ongRepository = ongRepository;
        }

        public async Task<bool> CreateNewOng(string nome, string email)
        {
            var ong = new Ong
            {
                NomeOng = nome,
                Email = email,
                Endereco = string.Empty,
                Cidade = string.Empty,
                Estado = string.Empty,
                Telefone = string.Empty,
                CEP = string.Empty,
                Tipo = OngType.Vazio
            };

            var result = await _ongRepository.AddOng(ong);

            return result;
        }

        public Ong? GetOng(string email)
        {
            return _ongRepository.GetOngByEmail(email);
        }

        public bool UpdateOng(Ong ong)
        {
            var result = _ongRepository.UpdateOng(ong);

            return result;
        }

        public bool RemoveOng(string email)
        {
            var obj = _ongRepository.GetOngByEmail(email);

            if(obj != null)
            {
                var result = _ongRepository.RemoveOng(obj);

                return result;
            }

            return false;
        }
    }
}
