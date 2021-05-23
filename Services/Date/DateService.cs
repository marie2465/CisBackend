using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Dates;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Date
{
    public class DateService : IDatesService
    {
        private readonly IMapper _mapper;
        private readonly CisDBContext db;
        public DateService(IMapper mapper, CisDBContext dBContext)
        {
            _mapper = mapper;
            db = dBContext;
        }
        public async Task<ServicesResponse<GetDatesDto>> Add(AddDatesDto add)
        {
            ServicesResponse<GetDatesDto> services = new ServicesResponse<GetDatesDto>();
            if (add == null) throw new Exception("Not found");
            var dates = _mapper.Map<AddDatesDto, Dates>(add);
            await db.Dates.AddAsync(dates);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetDatesDto>(dates);
            return services;
        }

        public async Task<ServicesResponse<List<GetDatesDto>>> Delete(int id)
        {
            ServicesResponse<List<GetDatesDto>> services = new ServicesResponse<List<GetDatesDto>>();
            var dates = await db.Dates.FirstOrDefaultAsync(c => c.Id == id);
            if (dates == null) throw new Exception();

            db.Dates.Remove(dates);
            await db.SaveChangesAsync();
            services.Data = db.Dates.Select(c => _mapper.Map<GetDatesDto>(c)).ToList();
            return services;
        }

        public async Task<ServicesResponse<List<GetDatesDto>>> GetAll()
        {
            ServicesResponse<List<GetDatesDto>> services = new ServicesResponse<List<GetDatesDto>>();
            services.Data = await (db.Dates.Select(c => _mapper.Map<GetDatesDto>(c))).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetDatesDto>> GetById(int id)
        {
            ServicesResponse<GetDatesDto> services = new ServicesResponse<GetDatesDto>();
            var dates = await db.Dates.FirstOrDefaultAsync(c => c.Id == id);
            if (dates == null) throw new Exception("Not found");

            services.Data = _mapper.Map<GetDatesDto>(dates);
            return services;
        }

        public async Task<ServicesResponse<List<GetDatesDto>>> GetByTime(DateTime times)
        {
            ServicesResponse<List<GetDatesDto>> services = new ServicesResponse<List<GetDatesDto>>();
            var dates = db.Dates.Where(c => c.Date == times).Select(a => a.Id);
            if(dates==null) throw new Exception("not found");

            services.Data = await (db.Dates.Select(c => _mapper.Map<GetDatesDto>(c))).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetDatesDto>> Update(int id, UpdateDatesDto update)
        {
            ServicesResponse<GetDatesDto> services = new ServicesResponse<GetDatesDto>();
            var dates = await db.Dates.FirstOrDefaultAsync(c => c.Id == id);
            if (dates == null) throw new Exception("Not found");

            if (update.Date != null || update.Date.ToString() != "") dates.Date = update.Date;
            if (update.Name != "") dates.Name = update.Name;
            dates.Id = id;
            db.Dates.Update(dates);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetDatesDto>(dates);
            return services;
        }
    }
}