using OngConnection.Application.DTO;
using OngConnection.Domain.Enums;

namespace OngConnection.Application.Interfaces
{
    public interface IUserServices
    {
        Task<bool> RegisterNewUser(UserType userType, string nome, string email);
        OngDTO GetOngByEmail(string email);
        SocialWorkerDTO GetSocialWorkerByEmail(string email);
		bool UpdateUser(OngDTO ong);
        bool UpdateUser(SocialWorkerDTO dto);
		bool RemoveUser(string email, string role);

	}
}
