using System.Threading.Tasks;
using Cis_part2.Dtos.Section;
using Cis_part2.Services.Section;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        public ISectionService _isectionService;
        public SectionController(ISectionService section)
        {
            _isectionService = section;
        }
        [HttpGet("skill/{skillId}/")]
        public async Task<IActionResult> Get(int skillId)
        {
            return Ok(await _isectionService.GetAll(skillId));
        }
        [HttpGet("skill/{skillId}/{id}")]
        public async Task<IActionResult> GetById(int skillId, int id)
        {
            return Ok(await _isectionService.GetById(skillId, id));
        }
        [HttpPost("skill/{skillId}/")]
        public async Task<IActionResult> Add(int skillId, AddSectionDto addSectionDto)
        {
            return Ok(await _isectionService.AddSection(skillId, addSectionDto));
        }
        [HttpPut("skill/{skillId}/{id}")]
        public async Task<IActionResult> Update(int skillId, int id, UpdateSectionDto updateSectionDto)
        {
            return Ok(await _isectionService.UpdateSection(skillId, id, updateSectionDto));
        }
        [HttpDelete("skill/{skillId}/{id}")]
        public async Task<IActionResult> Delete(int skillId, int id)
        {
            return Ok(await _isectionService.Delete(skillId, id));
        }
    }
}