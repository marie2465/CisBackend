using System.Threading.Tasks;
using Cis_part2.Models;

namespace Cis_part2.Data
{
    public interface IAuthRepository
    {
        Task<ServicesResponse<string>> Register(User user, string password);
        public Task<ServicesResponse<string>> Login (string login, string password);
        public Task<bool> UserExists (string login);
    }
}