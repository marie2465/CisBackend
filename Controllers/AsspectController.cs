using System.Threading.Tasks;
using Cis_part2.Dtos.Asspects;
using Cis_part2.Services.Asspects;
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
        public AsspectController(IAsspectService asspect)
        {
            _asspectService = asspect;
        }
        [HttpGet("subcritery/{subcriteryId}/")]
        public async Task<IActionResult> GetAll(int subcriteryId)
        {
            return Ok(await _asspectService.GetAll(subcriteryId));
        }
        [HttpGet("subcritery/{subcriteryId}/{id}")]
         public async Task<IActionResult> GetById(int subcriteryId, int id)
        {
            return Ok(await _asspectService.GetById(subcriteryId, id));
        }
        [HttpPost("subcritery/{subcriteryId}/")]
         public async Task<IActionResult> Add(int subcriteryId, AddAsspectDto asspectDto)
        {
            return Ok(await _asspectService.Add(subcriteryId, asspectDto));
        }
        [HttpPut("subcritery/{subcriteryId}/{id}")]
         public async Task<IActionResult> Update(int subcriteryId, int id, UpdateAsspectDto updateAsspect)
        {
            return Ok(await _asspectService.Update(subcriteryId, id, updateAsspect));
        }
        [HttpDelete("subcritery/{subcriteryId}/{id}")]
         public async Task<IActionResult> Delete(int subcriteryId, int id)
        {
            return Ok(await _asspectService.Delete(subcriteryId, id));
        }
    }
}