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
        public async Task<ServicesResponse<GetSectionDto>> AddSection(AddSectionDto addSectionDto)
        {
            ServicesResponse<GetSectionDto> services = new ServicesResponse<GetSectionDto>();
            if (addSectionDto == null) throw new Exception("Not found");
            if (addSectionDto.NameSection == null || addSectionDto.NameSection == "") throw new Exception("Not found");
            if (addSectionDto.Importance == 0) throw new Exception("Not found");
            var sections = _mapper.Map<AddSectionDto, Sections>(addSectionDto);
            await db.Sections.AddAsync(sections);
            await db.SaveChangesAsync();
            int idMax = await db.Sections.MaxAsync(c => c.Id);
            Sections sectionService = await db.Sections.FirstOrDefaultAsync(c => c.Id == idMax);
            services.Data = _mapper.Map<GetSectionDto>(sectionService);
            throw new System.NotImplementedException();
        }

        public Task<ServicesResponse<List<GetSectionDto>>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServicesResponse<List<GetSectionDto>>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServicesResponse<GetSectionDto>> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServicesResponse<GetSectionDto>> UpdateSection(int id, UpdateSectionDto updateSectionDto)
        {
            throw new System.NotImplementedException();
        }
    }
}