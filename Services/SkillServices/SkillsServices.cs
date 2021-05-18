using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Skills;
using Cis_part2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.SkillsServices
{
    public class SkillsServices : ISkillsServices
    {
        public readonly CisDBContext db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SkillsServices(CisDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        //add
        public async Task<ServicesResponse<GetSkillsDto>> AddSkills(AddSkillsDto addSkillsDto)
        {
            ServicesResponse<GetSkillsDto> services = new ServicesResponse<GetSkillsDto>();
            try
            {
                if (addSkillsDto.NameSkills == null || addSkillsDto.NameSkills == "") throw new Exception("Not found");
                if (addSkillsDto.CodeSkills == null || addSkillsDto.CodeSkills == "") throw new Exception("Not found");
                if (addSkillsDto.TypeSkillsId == null || addSkillsDto.TypeSkillsId == 0) throw new Exception("Not found");
                var skills = _mapper.Map<AddSkillsDto, Skills>(addSkillsDto);
                skills.User = await db.Users.FirstOrDefaultAsync(c => c.Id == GetUserId());

                await db.Skills.AddAsync(skills);
                await db.SaveChangesAsync();

                int idMax = await db.Skills.MaxAsync(c => c.Id);
                Skills skillsService = await db.Skills.Where(c => c.User.Id == GetUserId()).FirstOrDefaultAsync(c => c.Id == idMax);
                services.Data = _mapper.Map<GetSkillsDto>(skillsService);
            }
            catch (Exception e)
            {
                services.Success = false;
                services.Message = e.Message;
            }
            return services;
        }
        //delete
        public async Task<ServicesResponse<List<GetSkillsDto>>> DeleteSkills(int id)
        {
            ServicesResponse<List<GetSkillsDto>> services = new ServicesResponse<List<GetSkillsDto>>();
            Skills skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == id);
            if (skills == null) services.Message = "Not Found";
            db.Skills.Remove(skills);
            await db.SaveChangesAsync();
            services.Data = (db.Skills.Select(c => _mapper.Map<GetSkillsDto>(c))).ToList();
            return services;
        }
        //get all skills
        public async Task<ServicesResponse<List<GetSkillsDto>>> GetAll()
        {
            ServicesResponse<List<GetSkillsDto>> services = new ServicesResponse<List<GetSkillsDto>>();
            List<Skills> dbSkills = await db.Skills.Where(c => c.User.Id == GetUserId()).ToListAsync();
            services.Data = dbSkills.Select(c => _mapper.Map<GetSkillsDto>(c)).ToList();
            return services;
        }
        //get skills by id
        public async Task<ServicesResponse<GetSkillsDto>> GetSkillsById(int id)
        {
            ServicesResponse<GetSkillsDto> services = new ServicesResponse<GetSkillsDto>();
            var idMax = db.Skills.Max(c => c.Id);
            int idMin = db.Skills.Min(c => c.Id);
            if (idMin > id || id > idMax) services.Message = "Данной записи нет";
            Skills skills = await db.Skills.FirstOrDefaultAsync(c => c.Id == id);
            if (skills == null) services.Message = "Данной записи нет";
            services.Data = _mapper.Map<GetSkillsDto>(skills);
            return services;
        }

        public async Task<ServicesResponse<GetSkillsDto>> UpdateSkills(int id, UpdateSkillsDto updateSkills)
        {
            ServicesResponse<GetSkillsDto> services = new ServicesResponse<GetSkillsDto>();
            var skillUpdate = await db.Skills.FindAsync(id);
            if (skillUpdate == null) services.Message = "Not found";
            skillUpdate.Id = id;
            if (updateSkills.NameSkills != "" && updateSkills.CodeSkills == null) skillUpdate.NameSkills = updateSkills.NameSkills;
            if (updateSkills.CodeSkills != "" && updateSkills.NameSkills == null) skillUpdate.CodeSkills = updateSkills.CodeSkills;
            // if (updateSkills.TypeSkillsId != 0) skillUpdate.TypeSkillsId = updateSkills.TypeSkillsId;
            skillUpdate.NameSkills = updateSkills.NameSkills;
            skillUpdate.CodeSkills = updateSkills.CodeSkills;
            db.Skills.Update(skillUpdate);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetSkillsDto>(skillUpdate);
            return services;
        }
    }
}