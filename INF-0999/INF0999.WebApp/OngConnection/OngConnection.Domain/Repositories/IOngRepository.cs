using OngConnection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Repositories
{
    public interface IOngRepository
    {
        Task<bool> AddOng(Ong ong);
        IEnumerable<Ong> GetAllOngs();
        Ong? GetOngByEmail(string email);
        bool UpdateOng(Ong ong);
        bool RemoveOng(Ong ong);

    }
}
