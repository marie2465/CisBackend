using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Skills;
using Cis_part2.Models;

namespace Cis_part2.Services.SkillsServices
{
    public interface ISkillsServices
    {
        public Task<ServicesResponse<List<GetSkillsDto>>> GetAll();
        public Task<ServicesResponse<GetSkillsDto>> GetSkillsById(int id);
        public Task<ServicesResponse<GetSkillsDto>> AddSkills(AddSkillsDto addSkillsDto);
        public Task<ServicesResponse<GetSkillsDto>> UpdateSkills(int id, UpdateSkillsDto updateSkills);
        public Task<ServicesResponse<List<GetSkillsDto>>> DeleteSkills (int id);
    }
}