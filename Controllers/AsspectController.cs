using System.Threading.Tasks;
using Cis_part2.Dtos.Asspect;
using Cis_part2.Services.Asspect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AsspectController : ControllerBase
    {
        private readonly IAsspectService _asspectService;
        public AsspectController(IAsspectService asspectService)
        {
            _asspectService = asspectService;
        }
        [HttpGet("section/{sectionId}/")]
        public async Task<IActionResult> Get(int sectionId)
        {
            return Ok(await _asspectService.GetAll(sectionId));
        }
        [HttpGet("section/{sectionId}/{id}")]
        public async Task<IActionResult> GetById(int sectionId, int id)
        {
            return Ok(await _asspectService.GetById(sectionId, id));
        }
        [HttpPost("section/{sectionId}/")]
        public async Task<IActionResult> Add(int sectionId, AddAsspectDto addAsspectDto)
        {
            return Ok(await _asspectService.AddAsspect(sectionId, addAsspectDto));
        }
        [HttpPut("section/{sectionId}/{id}")]
        public async Task<IActionResult> Edit (int sectionId, int id, UpdateAsspectDto updateAsspect)
        {
            return Ok(await _asspectService.UpdateAsspect(sectionId, id, updateAsspect));
        }
        [HttpDelete("section/{sectionId}/{id}")]
        public async Task<IActionResult> Delete (int sectionId, int id)
        {
            return Ok(await _asspectService.DeleteAsspect(sectionId, id));
        }
    }
}