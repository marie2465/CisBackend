using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Asspects;
using Cis_part2.Models;

namespace Cis_part2.Services.Asspects
{
    public interface IAsspectService
    {
        public Task<ServicesResponse<List<GetAsspectDto>>> GetAll(int subcriteryId);
        public Task<ServicesResponse<GetAsspectDto>> GetById(int subcriteryId, int id);
        public Task<ServicesResponse<GetAsspectDto>> Add(int subcriteryId, AddAsspectDto addAsspect);
        public Task<ServicesResponse<GetAsspectDto>> Update(int subcriteryId, int id, UpdateAsspectDto updateAsspect);
        public Task<ServicesResponse<List<GetAsspectDto>>> Delete(int subcriteryId, int id);
    }
}