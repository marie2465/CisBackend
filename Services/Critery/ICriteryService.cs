using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Criteries;
using Cis_part2.Models;

namespace Cis_part2.Services.Critery
{
    public interface ICriteryService
    {
         public Task<ServicesResponse<List<GetCriteriesDto>>> GetAll(int skillsId);
         public Task<ServicesResponse<GetCriteriesDto>> GetById(int skillsId, int id);
         public Task<ServicesResponse<GetCriteriesDto>> Add(int skillsId, AddCriteriesDto addCriteriesDto);
         public Task<ServicesResponse<GetCriteriesDto>> UpdateCriteries (int skillsId, int id, UpdateCriteriesDto updateCriteriesDto);
         public Task<ServicesResponse<List<GetCriteriesDto>>> DeleteCriteries(int skillsId, int id);
    }
}