using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.SubCritery;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.SubCritery
{
    public class SubCriteriesService : ISubCriteriesService
    {
        public CisDBContext db;
        public IMapper _mapper;
        public SubCriteriesService(CisDBContext dBContext, IMapper mapper)
        {
            db = dBContext;
            _mapper = mapper;
        }

        public async Task<ServicesResponse<GetSubCriteriesDto>> Add(int criteryId, AddSubCriteriesDto addSubCriteries)
        {
            ServicesResponse<GetSubCriteriesDto> services = new ServicesResponse<GetSubCriteriesDto>();
            var critery = await db.Criteries.FirstOrDefaultAsync(c => c.Id == criteryId);
            if (critery == null) throw new Exception("Not Found");

            var subCrit = _mapper.Map<AddSubCriteriesDto, SubCriteries>(addSubCriteries);
            subCrit.CriteriesId = criteryId;
            await db.SubCriteries.AddAsync(subCrit);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetSubCriteriesDto>(subCrit);
            return services;
        }

        public async Task<ServicesResponse<List<GetSubCriteriesDto>>> Delete(int criteryId, int id)
        {
            ServicesResponse<List<GetSubCriteriesDto>> services = new ServicesResponse<List<GetSubCriteriesDto>>();
            var critery = await db.Criteries.FirstOrDefaultAsync(c => c.Id == criteryId);
            if (critery == null) throw new Exception("Not Found");

            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(a => a.Id == id);
            if (subCrit == null) throw new Exception("Not Found");

            db.SubCriteries.Remove(subCrit);
            await db.SaveChangesAsync();
            services.Data = await (db.SubCriteries.Select(c => _mapper.Map<GetSubCriteriesDto>(c))).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<List<GetSubCriteriesDto>>> GetAll(int criteryId)
        {
            ServicesResponse<List<GetSubCriteriesDto>> services = new ServicesResponse<List<GetSubCriteriesDto>>();
            var critery = await db.Criteries.FirstOrDefaultAsync(c => c.Id == criteryId);
            if (critery == null) throw new Exception("Not Found");

            services.Data = await db.SubCriteries.Select(c => _mapper.Map<GetSubCriteriesDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetSubCriteriesDto>> GetById(int criteryId, int id)
        {
            ServicesResponse<GetSubCriteriesDto> services = new ServicesResponse<GetSubCriteriesDto>();
            var critery = await db.Criteries.FirstOrDefaultAsync(c => c.Id == criteryId);
            if (critery == null) throw new Exception("Not Found");

            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(c => c.Id == id);
            services.Data = _mapper.Map<GetSubCriteriesDto>(subCrit);
            return services;
        }

        public async Task<ServicesResponse<GetSubCriteriesDto>> Update(int criteryId, int id, UpdateSubCriteriesDto update)
        {
            ServicesResponse<GetSubCriteriesDto> services = new ServicesResponse<GetSubCriteriesDto>();
            var critery = await db.Criteries.FirstOrDefaultAsync(c => c.Id == criteryId);
            if (critery == null) throw new Exception("Not Found");

            var subCrit = await db.SubCriteries.FirstOrDefaultAsync(c => c.Id == id);
            _mapper.Map(update, subCrit);
            db.SubCriteries.Update(subCrit);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetSubCriteriesDto>(subCrit);
            return services;
        }
    }
}