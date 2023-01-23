using Microsoft.Extensions.Logging;
using OngConnection.Application.DTO;
using OngConnection.Application.Interfaces;
using OngConnection.Domain.Enums;
using OngConnection.Domain.Interfaces;
using OngConnection.Domain.Models;
using System.Xml;

namespace OngConnection.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly ILogger<UserServices> _logger;
        private readonly IOngServices _ongServices;
        private readonly ISocialWorkerServices _socialWorkerServices;

        public UserServices(ILogger<UserServices> logger, IOngServices ongServices, ISocialWorkerServices socialWorkerServices)
        {
            _logger = logger;
            _ongServices = ongServices;
            _socialWorkerServices = socialWorkerServices;
        }

        public async Task<bool> RegisterNewUser(UserType userType, string nome, string email)
        {
            var result = false;

            if (userType.Equals(UserType.ONG))
            {
                result = await _ongServices.CreateNewOng(nome, email);
            }
            else if (userType.Equals(UserType.AssistenteSocial))
            {
                result = await _socialWorkerServices.CreateNewSocialWorker(nome, email);
            }

            return result;
        }

        public OngDTO GetOngByEmail(string email)
        {
            var ongDto = new OngDTO();

            var ong = _ongServices.GetOng(email);

            if(ong == null)
            {
                ongDto.ErrorCount += 1;
                ongDto.ErrorMessage = "Não foi possível encontrar a ONG com o email especificado.";
            }
            else
            {
                ongDto.NomeOng = ong.NomeOng;
                ongDto.Email = ong.Email;
                ongDto.Telefone = ong.Telefone;
                ongDto.CEP = ong.CEP;
                ongDto.Endereco = ong.Endereco;
                ongDto.Cidade = ong.Cidade;
                ongDto.Estado = ong.Estado;
                ongDto.Tipo = ong.Tipo;

                ongDto.ErrorMessage = "";
                ongDto.ErrorCount = 0;
            }

            return ongDto;
        }

        public SocialWorkerDTO GetSocialWorkerByEmail(string email)
        {
            var socialDto = new SocialWorkerDTO();

            var social = _socialWorkerServices.GetSocialWorker(email);

            if(social == null)
            {
                socialDto.ErrorCount += 1;
                socialDto.ErrorMessage = "Não foi possível encontrar o Assistente Social com o email especificado.";
            }
            else
            {
                socialDto.Nome = social.Nome;
                socialDto.Email = social.Email;
                socialDto.Telefone = social.Telefone;
                socialDto.CEP = social.CEP;
                socialDto.Endereco = social.Endereco;
                socialDto.Cidade = social.Cidade;
                socialDto.Estado = social.Estado;

                socialDto.ErrorMessage = "";
                socialDto.ErrorCount = 0;
            }

            return socialDto;
        }

        public bool UpdateUser(OngDTO dto)
        {
            var ong = new Ong
            {
                NomeOng = dto.NomeOng,
                Email = dto.Email,
                Telefone = dto.Telefone,
                CEP = dto.CEP,
                Endereco = dto.Endereco,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                Tipo = dto.Tipo
            };

            var result = _ongServices.UpdateOng(ong);

            return result;
        }

        public bool UpdateUser(SocialWorkerDTO dto)
        {
            var socialWorker = new SocialWorker
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                CEP = dto.CEP,
                Endereco = dto.Endereco,
                Cidade = dto.Cidade,
                Estado = dto.Estado
            };

            var result = _socialWorkerServices.UpdateSocialWorker(socialWorker);

            return result;
        }

        public bool RemoveUser(string email, string role)
        {
            var userType = ConvertRole(role);

            if (userType.Equals(UserType.ONG))
            {
                var result = _ongServices.RemoveOng(email);

                return result;
            }
            else if (userType.Equals(UserType.AssistenteSocial))
            {
                var result = _socialWorkerServices.RemoveSocialWorker(email);

                return result;
            }

            return false;
        }

        private UserType ConvertRole(string role)
        {
            if (UserType.ONG.GetDescription().Equals(role))
            {
                return UserType.ONG;
            }
            else if (UserType.AssistenteSocial.GetDescription().Equals(role))
            {
                return UserType.AssistenteSocial;
            }

			return UserType.Null;
        }
    }
}
