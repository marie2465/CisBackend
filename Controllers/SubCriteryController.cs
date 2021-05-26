using System.Threading.Tasks;
using Cis_part2.Dtos.Criteries;
using Cis_part2.Dtos.SubCritery;
using Cis_part2.Services.SubCritery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SubCriteryController : ControllerBase
    {
        private readonly ISubCriteriesService _subcriteryService;
        
        public SubCriteryController(ISubCriteriesService subCriteriesService)
        {
            _subcriteryService = subCriteriesService;
        }

        [HttpGet("critery/{criteryId}/")]
        public async Task<IActionResult> GetAll(int criteryId)
        {
            return Ok(await _subcriteryService.GetAll(criteryId));
        }
        [HttpGet("critery/{criteryId}/{id}")]
        public async Task<IActionResult> GetById(int criteryId, int id)
        {
            return Ok(await _subcriteryService.GetById(criteryId, id));
        }
        [HttpPost("critery/{criteryId}/")]
        public async Task<IActionResult> Add(int criteryId, AddSubCriteriesDto addCriteries)
        {
            return Ok(await _subcriteryService.Add(criteryId, addCriteries));
        }
        [HttpPut("critery/{criteryId}/{id}")]
        public async Task<IActionResult> GetAll(int criteryId, int id, UpdateSubCriteriesDto updateCriteries)
        {
            return Ok(await _subcriteryService.Update(criteryId, id, updateCriteries));
        }
        [HttpDelete("critery/{criteryId}/{id}")]
        public async Task<IActionResult> GetAll(int criteryId, int id)
        {
            return Ok(await _subcriteryService.Delete(criteryId, id));
        }
    }
}