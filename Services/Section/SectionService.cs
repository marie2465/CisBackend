using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Section;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Section
{
    public class SectionService : ISectionService
    {
        public CisDBContext db;
        public IMapper _mapper;

        public SectionService(CisDBContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        public async Task<ServicesResponse<GetSectionDto>> AddSection(int skillId, AddSectionDto addSectionDto)
        {
            ServicesResponse<GetSectionDto> services = new ServicesResponse<GetSectionDto>();
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillId);
            if (skills == null) throw new Exception("Not found");
            if (addSectionDto == null) throw new Exception("Not found");
            if (addSectionDto.NameSection == null || addSectionDto.NameSection == "") throw new Exception("Not found");
            if (addSectionDto.Importance == 0) throw new Exception("Not found");
            var sections = _mapper.Map<AddSectionDto, Sections>(addSectionDto);
            sections.SkillsId = skills.Id;
            await db.Sections.AddAsync(sections);
            await db.SaveChangesAsync();
            int idMax = await db.Sections.MaxAsync(c => c.Id);
            Sections sectionService = await db.Sections.FirstOrDefaultAsync(c => c.Id == idMax);
            services.Data = _mapper.Map<GetSectionDto>(sectionService);
            return services;
        }

        public async Task<ServicesResponse<List<GetSectionDto>>> Delete(int skillId, int id)
        {
            ServicesResponse<List<GetSectionDto>> services = new ServicesResponse<List<GetSectionDto>>();
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillId);
            if (skills == null) throw new Exception("Not found");
            Sections sections = await db.Sections.FirstOrDefaultAsync(c => c.Id == id);
            if (sections == null) throw new Exception("Not Found");
            db.Sections.Remove(sections);
            await db.SaveChangesAsync();
            services.Data = await db.Sections.Select(c => _mapper.Map<GetSectionDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<List<GetSectionDto>>> GetAll(int skillId)
        {
            ServicesResponse<List<GetSectionDto>> services = new ServicesResponse<List<GetSectionDto>>();
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillId);
            if (skills == null) throw new Exception("Not found");
            services.Data = await (db.Sections.Select(c => _mapper.Map<GetSectionDto>(c))).ToListAsync();
            return services;
        }


        public async Task<ServicesResponse<GetSectionDto>> GetById(int skillId, int id)
        {
            ServicesResponse<GetSectionDto> services = new ServicesResponse<GetSectionDto>();
            var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillId);
            if (skills == null) throw new Exception("Not found");
            var idMax = db.Sections.Max(c => c.Id);
            int idMin = db.Sections.Min(c => c.Id);
            if (idMin > id || id > idMax) services.Message = "Данной записи нет";
            Sections sections = await db.Sections.FirstOrDefaultAsync(c => c.Id == id);
            if (sections == null) throw new Exception("Not found");
            services.Data = _mapper.Map<GetSectionDto>(sections);
            return services;
        }

        public async Task<ServicesResponse<GetSectionDto>> UpdateSection(int skillId, int id, UpdateSectionDto updateSectionDto)
        {
            ServicesResponse<GetSectionDto> services = new ServicesResponse<GetSectionDto>();
            try
            {
                var skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == skillId);
                if (skills == null) throw new Exception("Not found");
                
                var idMax = db.Sections.Max(c => c.Id);
                int idMin = db.Sections.Min(c => c.Id);
                if (idMin > id || id > idMax) services.Message = "Данной записи нет";

                var sections = await db.Sections.FirstOrDefaultAsync(c => c.Id == id);
                _mapper.Map(updateSectionDto, sections);
                db.Sections.Update(sections);
                await db.SaveChangesAsync();
                services.Data = _mapper.Map<GetSectionDto>(sections);
            }
            catch (Exception e)
            {
                services.Message=e.Message;
            }
            return services;
        }
    }
}