using System;
using System.Threading.Tasks;
using Cis_part2.Models;

namespace Cis_part2.Data
{
    public class AuthRepository : IAuthRepository
    {
        //вход
        public async Task<ServicesResponse<string>> Login(string login, string password)
        {
            ServicesResponse<string> services = new ServicesResponse<string>();
            try{
                services.Data = login;
            }
            catch(Exception e)
            {
                services.Success = false;
                services.Message = e.Message;
            }
            return services;
        }
        //регистрация пользователя
        public async Task<ServicesResponse<string>> Register(User user, string password)
        {
            ServicesResponse<string> services = new ServicesResponse<string>();
            try{
                //добавление пользователя
            }
            catch(Exception e)
            {
                services.Success = false;
                services.Message = e.Message;
            }
            return services;
        }
        //проверка пользователя
        public async Task<bool> UserExists(string login)
        {
            ServicesResponse<string> services = new ServicesResponse<string>();
            //if(await db.AnyAsync(c => c.Login == login))
            //{
                //return true;
            //}
            return false;
        }
    }
}