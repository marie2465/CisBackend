using System.Threading.Tasks;
using Cis_part2.Dtos.PeopleInTeams;
using Cis_part2.Services.PeopleInTeam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PeoplesController:ControllerBase
    {
        private readonly IPeopleTeamService _peopleService;
        public PeoplesController(IPeopleTeamService peopleTeam)
        {
            _peopleService = peopleTeam;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _peopleService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _peopleService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPeopleTeamDto addPeople)
        {
            return Ok(await _peopleService.Add(addPeople));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await  _peopleService.Delete(id));
        }
    }
}