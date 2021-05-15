using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Skills;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.SkillsServices
{
    public class SkillsServices : ISkillsServices
    {
        public readonly CisDBContext db;
        private readonly IMapper _mapper;
        public SkillsServices(CisDBContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        public async Task<ServicesResponse<GetSkillsDto>> AddSkills(AddSkillsDto addSkillsDto)
        {
            ServicesResponse<GetSkillsDto> services = new ServicesResponse<GetSkillsDto>();
            try
            {
                
                Skills skills = _mapper.Map<Skills>(addSkillsDto);
                await db.Skills.AddAsync(skills);
                await db.SaveChangesAsync();
                int idMax = await db.Skills.MaxAsync(c => c.Id);
                Skills skillsService = await db.Skills.FirstOrDefaultAsync(c => c.Id == idMax);
                services.Data = _mapper.Map<GetSkillsDto>(skillsService);

            }
            catch (Exception e)
            {
                services.Success = false;
                services.Message = e.Message;
            }
            return services;
        }

        public async Task<ServicesResponse<List<GetSkillsDto>>> DeleteSkills(int id)
        {
            ServicesResponse<List<GetSkillsDto>> services = new ServicesResponse<List<GetSkillsDto>>();
            if (id == 0)
            {
                services.Success = false;
                services.Message = "Введите id";
            }
            else
            {
                Skills skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == id);
                if (skills == null)
                {
                    services.Success = false;
                    services.Message = "Данной компетенции нет";
                }
                else
                {
                    db.Skills.Remove(skills);
                    await db.SaveChangesAsync();
                    services.Data = (db.Skills.Select(c => _mapper.Map<GetSkillsDto>(c))).ToList();
                }
            }
            throw new System.NotImplementedException();
        }

        public async Task<ServicesResponse<List<GetSkillsDto>>> GetAll()
        {
            ServicesResponse<List<GetSkillsDto>> services = new ServicesResponse<List<GetSkillsDto>>();
            List<Skills> skillsList = await db.Skills.ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetSkillsDto>> GetSkillsById(int id)
        {
            ServicesResponse<GetSkillsDto> services = new ServicesResponse<GetSkillsDto>();
            if (id == 0)
            {

            }
            else
            {
                var idMax = db.Skills.Max(c => c.Id);
                int idMin = db.Skills.Min(c => c.Id);
                if (idMin > id || id > idMax)
                {
                    services.Success = false;
                    services.Message = "Данной записи нет";
                }
                else
                {
                    Skills skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == id);
                    if (skills == null)
                    {
                        services.Success = false;
                        services.Message = "Данной записи нет";
                    }
                    else
                    {
                        services.Data = _mapper.Map<GetSkillsDto>(skills);
                    }
                }
            }
            return services;
        }

        public Task<ServicesResponse<GetSkillsDto>> UpdateSkills(UpdateSkillsDto updateSkills)
        {
            ServicesResponse<GetSkillsDto> services = new ServicesResponse<GetSkillsDto>();

            throw new System.NotImplementedException();
        }
    }
}