using System.Threading.Tasks;
using Cis_part2.Dtos.Criteries;
using Cis_part2.Services.Critery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    public class CriteryController : ControllerBase
    {
        private readonly ICriteryService _criteryService;
        public CriteryController(ICriteryService critery)
        {
            _criteryService = critery;
        }
        [HttpGet("skills/{skillsId}/")]
        public async Task<IActionResult> Get(int skillsId)
        {
            return Ok(await _criteryService.GetAll(skillsId));
        }
        [HttpGet("skills/{skillsId}/{id}")]
        public async Task<IActionResult> GetById(int skillsId, int id)
        {
            return Ok(await _criteryService.GetById(skillsId, id));
        }
        [HttpPost("skills/{skillsId}/")]
        public async Task<IActionResult> Add(int skillsId, AddCriteriesDto addCriteries)
        {
            return Ok(await _criteryService.Add(skillsId, addCriteries));
        }
        [HttpGet("skills/{skillsId}/{id}")]
        public async Task<IActionResult> Update(int skillsId, int id, UpdateCriteriesDto updateCriteries)
        {
            return Ok(await _criteryService.UpdateCriteries(skillsId, id, updateCriteries));
        }
        [HttpDelete("skills/{skillsId}/{id}")]
        public async Task<IActionResult> Delete(int skillsId, int id)
        {
            return Ok(await _criteryService.DeleteCriteries(skillsId, id));
        }
    }
}