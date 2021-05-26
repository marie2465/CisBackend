using System.Threading.Tasks;
using Cis_part2.Dtos.Teams;
using Cis_part2.Services.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        public TeamsController(ITeamsService teams)
        {
            _teamsService = teams;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _teamsService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _teamsService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTeamsDto addTeam)
        {
            return Ok(await _teamsService.Add(addTeam));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _teamsService.Delete(id));
        }
    }
}