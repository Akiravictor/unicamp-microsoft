using OngConnection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Interfaces
{
    public interface IOngServices
    {
        Task<bool> CreateNewOng(string nome, string email);
        Ong? GetOng(string email);
        bool UpdateOng(Ong ong);
        bool RemoveOng(string email);

	}
}
