using System.Threading.Tasks;
using Cis_part2.Dtos.Persons;
using Cis_part2.Services.Persons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _personService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _personService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPersonDto addPerson)
        {
            return Ok(await _personService.Add(addPerson));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePersonDto update)
        {
            return Ok(await _personService.Update(id, update));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _personService.Delete(id));
        }
    }
}