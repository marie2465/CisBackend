using System;
using System.Threading.Tasks;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cis_part2.Data
{
    public class AuthRepository : IAuthRepository
    {
        string passSalts;
        private readonly IConfiguration _configuration;
        private readonly CisDBContext db;
        public AuthRepository(CisDBContext context, IConfiguration configuration)
        {
            db = context;
            _configuration = configuration;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        //вход
        public async Task<ServicesResponse<string>> Login(string login, string password)
        {
            ServicesResponse<string> services = new ServicesResponse<string>();
            User user = await db.Users.FirstOrDefaultAsync(c => c.Login.Equals(login));
            try
            {
                if (user == null)
                {
                    services.Success = false;
                    services.Message = "User not found";
                }
                else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    services.Success = false;
                    services.Message = "Введите пароль";
                }
                else
                {
                    services.Data = user.Login + "\t" + user.PasswordSalt;
                }
            }
            catch (Exception e)
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
            try
            {
                //добавление пользователя
                if (await UserExists(user.Login))
                {
                    services.Success = false;
                    services.Message = "User alredy exists";
                }
                //ничего в запросе не введено
                else if (user.UserName == null && user.Login == null && password == null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                //проверка на отсутствующее поле
                else if (user.UserName != null && user.Login == null && password == null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == null && user.Login != null && password == null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == null && user.Login == null && password != null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == null && user.Login == null && password == null && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != null && user.Login != null && password == null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != null && user.Login == null && password != null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != null && user.Login == null && password == null && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == null && user.Login != null && password != null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == null && user.Login != null && password == null && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == null && user.Login == null && password != null && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != null && user.Login != null && password != null && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                //проверка на пустоту сток
                else if (user.UserName != "" && user.Login == "" && password == "" && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == "" && user.Login != "" && password == "" && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == "" && user.Login == "" && password != "" && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == "" && user.Login == "" && password == "" && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != "" && user.Login != "" && password == "" && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != "" && user.Login == "" && password != "" && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != "" && user.Login == "" && password == "" && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == "" && user.Login != "" && password != "" && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == "" && user.Login != "" && password == "" && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName == "" && user.Login == "" && password != "" && user.RoleId != 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                else if (user.UserName != "" && user.Login != "" && password != "" && user.RoleId == 0)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                //добавление пользователя
                else if (user.UserName != "" && user.Login != "" && password != "" && user.RoleId != 0)
                {
                    CreatePasswordHash(password, out byte[] passHash, out byte[] passSalt);
                    user.PasswordSalt = passSalt;
                    user.PasswordHash = passHash;
                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                    services.Data = "Вы успешно зарегистрированы";
                }
            }
            catch (Exception e)
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
            if (await db.Users.AnyAsync(c => c.Login == login))
            {
                return true;
            }
            return false;
        }
    }
}