using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Dtos.Users;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cis_part2.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly CisDBContext db;
        private readonly IMapper _mapper;
        public AuthRepository(CisDBContext context, IConfiguration configuration, IMapper mapper)
        {
            db = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passSalt)
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
                    services.Data = CreateToken(user);
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
                if (user == null)
                {
                    services.Success = false;
                    services.Message = "Введите данные";
                }
                CreatePasswordHash(password, out byte[] passHash, out byte[] passSalt);
                user.PasswordSalt = passSalt;
                user.PasswordHash = passHash;
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                services.Data = "Вы успешно зарегистрированы";
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

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}