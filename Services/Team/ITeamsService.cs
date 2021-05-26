using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Teams;
using Cis_part2.Models;

namespace Cis_part2.Services.Team
{
    public interface ITeamsService
    {
        public Task<ServicesResponse<GetTeamsDto>> Add(AddTeamsDto addTeams);
        public Task<ServicesResponse<List<GetTeamsDto>>> GetAll();
        public Task<ServicesResponse<GetTeamsDto>> GetById(int id);
        public Task<ServicesResponse<List<GetTeamsDto>>> Delete(int id);
    }
}