using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Dtos.Skills;
using Cis_part2.Models;
using Cis_part2.Services.SkillsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        public static ClaimsPrincipal User { get; }
       
        private readonly ISkillsServices _skillsService;
        public SkillController(ISkillsServices skillsServices)
        {
            _skillsService = skillsServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetSkillsList()
        {
            return Ok(await _skillsService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _skillsService.GetSkillsById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddSkillsDto addSkillsDto)
        {
            return Ok(await _skillsService.AddSkills(addSkillsDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSkillsDto updateSkills)
        {
            ServicesResponse<GetSkillsDto> response = await _skillsService.UpdateSkills(id, updateSkills);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkills (int id)
        {
            return Ok(await _skillsService.DeleteSkills(id));
        }
    }
}