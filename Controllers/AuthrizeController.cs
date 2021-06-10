using System.Threading.Tasks;
using Cis_part2.Data;
using Cis_part2.Dtos.Users;
using Cis_part2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("[controller]")]
    public class AuthrizeController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthrizeController(IAuthRepository repository)
        {
            _authRepository = repository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> AddUser(UserRegisterDto userRegisterDto)
        {
            ServicesResponse<string> response = await _authRepository.Register(
                new User { UserName = userRegisterDto.UserName, Login = userRegisterDto.Login, RolesId = userRegisterDto.RolesId }, userRegisterDto.Password
            );
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            ServicesResponse<string> response = await _authRepository.Login(
                userLogin.Login, userLogin.Password
            );
            return Ok(response);
        }
    }
}