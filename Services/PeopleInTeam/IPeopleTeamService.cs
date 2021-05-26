using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.PeopleInTeams;
using Cis_part2.Models;

namespace Cis_part2.Services.PeopleInTeam
{
    public interface IPeopleTeamService
    {
        public Task<ServicesResponse<List<GetPeopleTeamDto>>> GetAll();
        public Task<ServicesResponse<GetPeopleTeamDto>> GetById(int id);
        public Task<ServicesResponse<GetPeopleTeamDto>> Add(AddPeopleTeamDto addPeople);
        public Task<ServicesResponse<List<GetPeopleTeamDto>>> Delete(int id);
    }
}