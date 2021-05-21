using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Asspect;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Asspect
{
    public class AsspectService : IAsspectService
    {
        public readonly CisDBContext db;
        public readonly IMapper _mapper;
        public AsspectService(CisDBContext dBContext, IMapper mapper)
        {
            db = dBContext;
            _mapper = mapper;
        }
        public async Task<ServicesResponse<GetAsspectDto>> AddAsspect(int sectionsId, AddAsspectDto addAsspect)
        {
            ServicesResponse<GetAsspectDto> services = new ServicesResponse<GetAsspectDto>();
            var section = await db.Sections.FirstOrDefaultAsync(c => c.Id == sectionsId);
            if (section == null) throw new Exception();

            var asspect = _mapper.Map<AddAsspectDto, Asspects>(addAsspect);
            await db.Asspects.AddAsync(asspect);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetAsspectDto>(asspect);
            return services;
        }

        public async Task<ServicesResponse<List<GetAsspectDto>>> DeleteAsspect(int sectionsId, int id)
        {
            ServicesResponse<List<GetAsspectDto>> services = new ServicesResponse<List<GetAsspectDto>>();
            var section = await db.Sections.FirstOrDefaultAsync(c => c.Id == sectionsId);
            if (section == null) throw new Exception();

            var asspect = await db.Asspects.FirstOrDefaultAsync(a => a.Id == id);
            if (asspect == null) throw new Exception();
            db.Asspects.Remove(asspect);
            await db.SaveChangesAsync();
            services.Data = db.Asspects.Select(c => _mapper.Map<GetAsspectDto>(c)).ToList();
            return services;
        }

        public async Task<ServicesResponse<List<GetAsspectDto>>> GetAll(int sectionsId)
        {
            ServicesResponse<List<GetAsspectDto>> services = new ServicesResponse<List<GetAsspectDto>>();
            var section = await db.Sections.FirstOrDefaultAsync(c => c.Id == sectionsId);
            if (section == null) throw new Exception();

            services.Data = db.Asspects.Select(c => _mapper.Map<GetAsspectDto>(c)).ToList();
            return services;
        }

        public async Task<ServicesResponse<GetAsspectDto>> GetById(int sectionsId, int id)
        {
            ServicesResponse<GetAsspectDto> services = new ServicesResponse<GetAsspectDto>();
            var section = await db.Sections.FirstOrDefaultAsync(c => c.Id == sectionsId);
            if (section == null) throw new Exception();

            var asspect = await db.Asspects.FirstOrDefaultAsync(a => a.Id == id);
            if (asspect == null) throw new Exception();
            services.Data = _mapper.Map<GetAsspectDto>(asspect);
            return services;
        }

        public async Task<ServicesResponse<GetAsspectDto>> UpdateAsspect(int sectionsId, int id, UpdateAsspectDto updateAsspectDto)
        {
            ServicesResponse<GetAsspectDto> services = new ServicesResponse<GetAsspectDto>();
            var section = await db.Sections.FirstOrDefaultAsync(c => c.Id == sectionsId);
            if (section == null) throw new Exception();

            var asspect = await db.Asspects.FirstOrDefaultAsync(c => c.Id == id);
            if (updateAsspectDto.Description != "") asspect.Description = updateAsspectDto.Description;
            if (updateAsspectDto.MaxMark != 0) asspect.MaxMark = updateAsspectDto.MaxMark;
            db.Asspects.Update(asspect);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetAsspectDto>(asspect);
            return services;
        }
    }
}