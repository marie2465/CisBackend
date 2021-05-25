using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.SubCritery;
using Cis_part2.Models;

namespace Cis_part2.Services.SubCritery
{
    public interface ISubCriteriesService
    {
         public Task<ServicesResponse<List<GetSubCriteriesDto>>> GetAll(int criteryId);
         public Task<ServicesResponse<GetSubCriteriesDto>> GetById(int criteryId, int id);
         public Task<ServicesResponse<GetSubCriteriesDto>> Add(int criteryId, AddSubCriteriesDto addSubCriteries);
         public Task<ServicesResponse<GetSubCriteriesDto>> Update(int criteryId, int id, UpdateSubCriteriesDto update);
         public Task<ServicesResponse<List<GetSubCriteriesDto>>> Delete(int criteryId, int id);
    }
}