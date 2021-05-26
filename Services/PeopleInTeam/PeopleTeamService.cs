using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.PeopleInTeams;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.PeopleInTeam
{
    public class PeopleTeamService : IPeopleTeamService
    {
        private readonly CisDBContext db;
        private readonly IMapper _mapper;
        public PeopleTeamService(CisDBContext dBContext, IMapper mapper)
        {
            db = dBContext;
            _mapper = mapper;
        }

        public async Task<ServicesResponse<GetPeopleTeamDto>> Add(AddPeopleTeamDto addPeople)
        {
            ServicesResponse<GetPeopleTeamDto> services = new ServicesResponse<GetPeopleTeamDto>();
            var people = _mapper.Map<AddPeopleTeamDto, PeopleInTeams>(addPeople);
            await db.PeopleInTeams.AddAsync(people);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetPeopleTeamDto>(people);
            return services;
        }

        public async Task<ServicesResponse<List<GetPeopleTeamDto>>> Delete(int id)
        {
            ServicesResponse<List<GetPeopleTeamDto>> services = new ServicesResponse<List<GetPeopleTeamDto>>();
            var people = await db.PeopleInTeams.FirstOrDefaultAsync(c => c.Id == id);
            if (people == null) throw new System.Exception("Not Found");

            db.PeopleInTeams.Remove(people);
            await db.SaveChangesAsync();
            services.Data = await db.PeopleInTeams.Select(c => _mapper.Map<GetPeopleTeamDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<List<GetPeopleTeamDto>>> GetAll()
        {
            ServicesResponse<List<GetPeopleTeamDto>> services = new ServicesResponse<List<GetPeopleTeamDto>>();
            services.Data = await db.PeopleInTeams.Select(c => _mapper.Map<GetPeopleTeamDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetPeopleTeamDto>> GetById(int id)
        {
            ServicesResponse<GetPeopleTeamDto> services = new ServicesResponse<GetPeopleTeamDto>();
            var people = await db.PeopleInTeams.FirstOrDefaultAsync(c => c.Id == id);
            if (people == null) throw new System.Exception("Not Found");
            services.Data = _mapper.Map<GetPeopleTeamDto>(people);
            return services;
        }
    }
}