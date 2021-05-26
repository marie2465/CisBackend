using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Teams;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Team
{
    public class TeamService : ITeamsService
    {
        private readonly CisDBContext db;
        private readonly IMapper _mapper;
        public TeamService(CisDBContext dBContext, IMapper mapper)
        {
            db = dBContext;
            _mapper = mapper;
        }
        public async Task<ServicesResponse<GetTeamsDto>> Add(AddTeamsDto addTeams)
        {
            ServicesResponse<GetTeamsDto> services = new ServicesResponse<GetTeamsDto>();
            var teams = _mapper.Map<AddTeamsDto, Teams>(addTeams);
            await db.Teams.AddAsync(teams);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetTeamsDto>(teams);
            return services;
        }

        public async Task<ServicesResponse<List<GetTeamsDto>>> Delete(int id)
        {
            ServicesResponse<List<GetTeamsDto>> services = new ServicesResponse<List<GetTeamsDto>>();
            var teams = await db.Teams.FirstOrDefaultAsync(c => c.Id == id);
            if (teams == null) throw new System.Exception("Not Found");
            db.Teams.Remove(teams);
            await db.SaveChangesAsync();
            services.Data = db.Teams.Include(c => c.PeopleInTeams).Select(c => _mapper.Map<GetTeamsDto>(c)).ToList();
            return services;
        }

        public async Task<ServicesResponse<List<GetTeamsDto>>> GetAll()
        {
            ServicesResponse<List<GetTeamsDto>> services = new ServicesResponse<List<GetTeamsDto>>();
            List<Teams> teams = await db.Teams.Include(c => c.PeopleInTeams).ToListAsync();
            services.Data = await db.Teams.Select(c => _mapper.Map<GetTeamsDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetTeamsDto>> GetById(int id)
        {
            ServicesResponse<GetTeamsDto> services = new ServicesResponse<GetTeamsDto>();
            var teams = await db.Teams.Include(c => c.PeopleInTeams)
                            .FirstOrDefaultAsync(c => c.Id == id);
            if(teams == null) throw new System.Exception("Not Found");
            services.Data = _mapper.Map<GetTeamsDto>(teams);
            return services;
        }
    }
}