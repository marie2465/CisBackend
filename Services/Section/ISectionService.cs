using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Section;
using Cis_part2.Models;

namespace Cis_part2.Services.Section
{
    public interface ISectionService
    {
         public Task<ServicesResponse<List<GetSectionDto>>> GetAll ();
         public Task<ServicesResponse<GetSectionDto>> GetById(int id);
         public Task<ServicesResponse<GetSectionDto>> AddSection (AddSectionDto addSectionDto);
         public Task<ServicesResponse<GetSectionDto>> UpdateSection (int id, UpdateSectionDto updateSectionDto);
         public Task<ServicesResponse<List<GetSectionDto>>> Delete (int id);
    }
}