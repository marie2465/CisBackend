using System.Threading.Tasks;
using Cis_part2.Dtos.Scores;
using Cis_part2.Services.Scores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ScoreController:ControllerBase
    {
        private readonly IScoreService _scoreService;
        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet("asspect/{asspectId}/")]
        public async Task<IActionResult> GetAll(int asspectId)
        {
            return Ok(await _scoreService.GetAll(asspectId));
        }
        [HttpGet("asspect/{asspectId}/{id}")]
        public async Task<IActionResult> GetById(int asspectId, int id)
        {
            return Ok(await _scoreService.GetById(asspectId, id));
        }
        [HttpPost("asspect/{asspectId}/")]
        public async Task<IActionResult> Add(int asspectId, AddScoreDto addScore)
        {
            return Ok(await _scoreService.Add(asspectId, addScore));
        }
        [HttpPut("asspect/{asspectId}/{id}")]
        public async Task<IActionResult> Update(int asspectId, int id, UpdateScoreDto updateScore)
        {
            return Ok(await _scoreService.Update(asspectId, id, updateScore));
        }
        [HttpDelete("asspect/{asspectId}/{id}")]
        public async Task<IActionResult> Delete(int asspectId, int id)
        {
            return Ok(await _scoreService.Delete(asspectId, id));
        }
    }
}