using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Criteries;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Critery
{
    public class CriteryService : ICriteryService
    {
        public CisDBContext db;
        public IMapper _mapper;
        public CriteryService(CisDBContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        public async Task<ServicesResponse<GetCriteriesDto>> Add(int skillsId, AddCriteriesDto addCriteriesDto)
        {
            ServicesResponse<GetCriteriesDto> services = new ServicesResponse<GetCriteriesDto>();
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillsId);
            if (skills == null) throw new Exception("Not Found");

            var critery = _mapper.Map<AddCriteriesDto, Criteries>(addCriteriesDto);
            await db.Criteries.AddAsync(critery);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetCriteriesDto>(critery);
            return services;
        }

        public async Task<ServicesResponse<List<GetCriteriesDto>>> DeleteCriteries(int skillsId, int id)
        {
            ServicesResponse<List<GetCriteriesDto>> services = new ServicesResponse<List<GetCriteriesDto>>();
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillsId);
            if (skills == null) throw new Exception("Not Found");

            var critery = await db.Criteries.FirstOrDefaultAsync(a => a.Id == id);
            db.Criteries.Remove(critery);
            await db.SaveChangesAsync();
            services.Data = await (db.Criteries.Select(c => _mapper.Map<GetCriteriesDto>(c))).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<List<GetCriteriesDto>>> GetAll(int skillsId)
        {
            ServicesResponse<List<GetCriteriesDto>> services = new ServicesResponse<List<GetCriteriesDto>>();
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillsId);
            if (skills == null) throw new Exception("Not Found");
            services.Data = await (db.Criteries.Select(c => _mapper.Map<GetCriteriesDto>(c))).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetCriteriesDto>> GetById(int skillsId, int id)
        {
            ServicesResponse<GetCriteriesDto> services = new ServicesResponse<GetCriteriesDto>(); 
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillsId);
            if (skills == null) throw new Exception("Not Found");

            var critery = await db.Criteries.FirstOrDefaultAsync(a => a.Id == id);
            services.Data = _mapper.Map<GetCriteriesDto>(critery);
            return services;
        }

        public async Task<ServicesResponse<GetCriteriesDto>> UpdateCriteries(int skillsId, int id, UpdateCriteriesDto updateCriteriesDto)
        {
            ServicesResponse<GetCriteriesDto> services = new ServicesResponse<GetCriteriesDto>(); 
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillsId);
            if (skills == null) throw new Exception("Not Found");

            var critery = await db.Criteries.FirstOrDefaultAsync(a => a.Id == id);
            if(updateCriteriesDto.Letter!="") critery.Letter = updateCriteriesDto.Letter;
            if(updateCriteriesDto.Mark!=0) critery.Mark = updateCriteriesDto.Mark;
            if(updateCriteriesDto.Name !="") critery.Name = updateCriteriesDto.Name;
            db.Criteries.Update(critery);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetCriteriesDto>(critery);
            return services;
        }
    }
}