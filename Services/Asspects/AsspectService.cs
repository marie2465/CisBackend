using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Asspects;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Asspects
{
    public class AsspectService : IAsspectService
    {
        public CisDBContext db;
        public IMapper _mapper;

        public AsspectService(CisDBContext dBContext, IMapper mapper)
        {
            db = dBContext;
            _mapper = mapper;
        }

        public async Task<ServicesResponse<GetAsspectDto>> Add(int subcriteryId, AddAsspectDto addAsspect)
        {
            ServicesResponse<GetAsspectDto> services = new ServicesResponse<GetAsspectDto>();
            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(c => c.Id == subcriteryId);
            if (subCrit == null) throw new Exception("Not Found");

            var asspect = _mapper.Map<AddAsspectDto, Asspect>(addAsspect);
            asspect.SubCriteriesId = subCrit.Id;
            await db.Asspect.AddAsync(asspect);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetAsspectDto>(asspect);
            return services;
        }

        public async Task<ServicesResponse<List<GetAsspectDto>>> Delete(int subcriteryId, int id)
        {
            ServicesResponse<List<GetAsspectDto>> services = new ServicesResponse<List<GetAsspectDto>>();
            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(c => c.Id == subcriteryId);
            if (subCrit == null) throw new Exception("Not Found");

            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == id);
            if (asspect == null) throw new Exception("not Found");

            db.Asspect.Remove(asspect);
            await db.SaveChangesAsync();
            services.Data = await db.Asspect.Select(c => _mapper.Map<GetAsspectDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<List<GetAsspectDto>>> GetAll(int subcriteryId)
        {
            ServicesResponse<List<GetAsspectDto>> services = new ServicesResponse<List<GetAsspectDto>>();
            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(c => c.Id == subcriteryId);
            if (subCrit == null) throw new Exception("Not Found");

            services.Data = await db.Asspect.Select(c => _mapper.Map<GetAsspectDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetAsspectDto>> GetById(int subcriteryId, int id)
        {
            ServicesResponse<GetAsspectDto> services = new ServicesResponse<GetAsspectDto>();
            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(c => c.Id == subcriteryId);
            if (subCrit == null) throw new Exception("Not Found");

            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == id);
            services.Data = _mapper.Map<GetAsspectDto>(asspect);
            return services;
        }

        public async Task<ServicesResponse<GetAsspectDto>> Update(int subcriteryId, int id, UpdateAsspectDto updateAsspect)
        {
            ServicesResponse<GetAsspectDto> services = new ServicesResponse<GetAsspectDto>();
            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(c => c.Id == subcriteryId);
            if (subCrit == null) throw new Exception("Not Found");

            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == id);
            _mapper.Map(updateAsspect, asspect);
            db.Asspect.Update(asspect);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetAsspectDto>(asspect);
            return services;
        }
    }
}