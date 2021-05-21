using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Asspect;
using Cis_part2.Models;

namespace Cis_part2.Services.Asspect
{
    public interface IAsspectService
    {
         public Task<ServicesResponse<List<GetAsspectDto>>> GetAll(int sectionsId);
         public Task<ServicesResponse<GetAsspectDto>> GetById(int sectionsId, int id);
         public Task<ServicesResponse<GetAsspectDto>> AddAsspect(int sectionsId, AddAsspectDto addAsspect);
         public Task<ServicesResponse<GetAsspectDto>> UpdateAsspect(int sectionsId, int id, UpdateAsspectDto updateAsspectDto);
         public Task<ServicesResponse<List<GetAsspectDto>>> DeleteAsspect (int sectionsId, int id);         
    }
}